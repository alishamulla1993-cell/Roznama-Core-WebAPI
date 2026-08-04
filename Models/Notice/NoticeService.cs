using Roznama.Models.Notice;
using Roznama.Models.Notice.Models;
using Roznama.Modules.Common;
using Roznama.Modules.Notice.Models;

namespace Roznama.Modules.Notice
{
    public class NoticeService
    {
        private readonly DropdownRepository _dropdownRepo;
        private readonly NoticeRepository _repo;

        public NoticeService(DropdownRepository dropdownRepo, NoticeRepository repo)
        {
            _dropdownRepo = dropdownRepo;
            _repo = repo;
        }
        public async Task<NoticeSummaryInitResponse> GetSummaryInitAsync(NoticeFilterDto filter)
        {
            // run independent dropdowns in parallel
            var entitiesTask = _dropdownRepo.GetEntities(0, filter.UserOID, filter.Role);
            var zonesTask = _dropdownRepo.GetZones(0, 0, filter.UserOID);
            var classTask = _dropdownRepo.GetClassificationTypes();
            var statusTask = _dropdownRepo.GetStatuses(0);
            var riskTask = _dropdownRepo.GetRiskDetails();
            var noticeTypeTask = _dropdownRepo.GetNoticeTypes();
            var rlmTask = _dropdownRepo.GetRLMs();

            // dependent (categories/subcategories) - fetch only if classification/category provided in filter
            Task<IEnumerable<dynamic>> categoriesTask = Task.FromResult<IEnumerable<dynamic>>(new List<dynamic>());
            Task<IEnumerable<dynamic>> subCategoriesTask = Task.FromResult<IEnumerable<dynamic>>(new List<dynamic>());

            if (filter.SubClassificationTypeOID != null && filter.SubClassificationTypeOID != 0)
            {
                categoriesTask = _dropdownRepo.GetCategoryTypes(filter.SubClassificationTypeOID.Value);
            }
            else if (filter.ClassificationTypeOID != null && filter.ClassificationTypeOID != 0)
            {
                categoriesTask = _dropdownRepo.GetCategoryTypes(filter.ClassificationTypeOID.Value);
            }

            if (filter.CategoryTypeOID != null && filter.CategoryTypeOID != 0)
            {
                subCategoriesTask = _dropdownRepo.GetSubCategoryTypes(filter.CategoryTypeOID.Value);
            }

            // start summary & total count in parallel too
            var summaryTask = _repo.GetNoticeSummaryAsync(filter); // returns IEnumerable<dynamic>
            var totalCountTask = _repo.GetNoticeSummaryTotalCount(filter); // returns int or object; adjust

            // Wait all
            await Task.WhenAll(entitiesTask, zonesTask, classTask, statusTask, riskTask, noticeTypeTask, rlmTask, categoriesTask, subCategoriesTask, summaryTask, totalCountTask);

            // If Entities returned exactly one, fetch units for that entity (optional)
            var entities = entitiesTask.Result;
            IEnumerable<dynamic> units = new List<dynamic>();
            if (entities != null)
            {
                var entList = entities.ToList();
                if (entList.Count == 1)
                {
                    var entId = (int)entList[0].EntityOID;
                    units = await _dropdownRepo.GetUnits(entId, filter.UserOID);
                }
            }

            // Prepare combined response
            var response = new NoticeSummaryInitResponse
            {
                Entities = entitiesTask.Result,
                Units = units,
                Zones = zonesTask.Result,
                Regions = new List<dynamic>(), // regions will be loaded on zone change client-side
                Classifications = classTask.Result,
                Categories = categoriesTask.Result,
                SubCategories = subCategoriesTask.Result,
                Statuses = statusTask.Result,
                Risks = riskTask.Result,
                NoticeTypes = noticeTypeTask.Result,
                Rlms = rlmTask.Result,
                Summary = summaryTask.Result,
                TotalRecords = ExtractTotalCount(totalCountTask.Result)
            };

            return response;
        }

        private int ExtractTotalCount(object totalResult)
        {
            // NoticeRepository.GetNoticeSummaryTotalCountAsync might return IEnumerable<dynamic> or scalar.
            // Normalize to int:
            if (totalResult == null) return 0;
            if (totalResult is int i) return i;
            if (totalResult is IEnumerable<dynamic> list)
            {
                var arr = list.ToList();
                if (arr.Count > 0)
                {
                    if (arr[0].TotalRecords != null) return (int)arr[0].TotalRecords;
                    if (arr[0].TotalRecordsCount != null) return (int)arr[0].TotalRecordsCount;
                }
            }
            if (int.TryParse(totalResult.ToString(), out var parsed)) return parsed;
            return 0;
        }
        public async Task<NoticeDetailDto?> GetNoticeDetailAsync(int noticeOID)
        {
            return await _repo.GetNoticeDetailAsync(noticeOID);
        }

        public async Task<IEnumerable<dynamic>> GetSummaryAsync(NoticeFilterDto filter)
        {
            return await _repo.GetNoticeSummaryAsync(filter);
        }
        public async Task<IEnumerable<dynamic>> GetNoticeSummaryTotalCount(NoticeFilterDto filter)
        {
            return await _repo.GetNoticeSummaryTotalCount(filter);
        }

        public async Task<List<NoticeUnitMemberDto>> GenerateUnitMembersAsync(
  NoticeGenerateUnitMemberRequest request)
        {
            var result = new List<NoticeUnitMemberDto>();
            int count = 0;

            if (request.ExistingMembers != null && request.ExistingMembers.Count > 0)
            {
                foreach (var item in request.ExistingMembers)
                {
                    if (request.UnitMemberOID != item.UnitMemberOID &&
                        request.UnitMember != item.UnitMember)
                    {
                        count++;
                        result.Add(new NoticeUnitMemberDto
                        {
                            SN = count,
                            UnitMemberOID = item.UnitMemberOID,
                            UnitMember = item.UnitMember
                        });
                    }
                }
            }

            if (request.UnitMemberOID > 0 && !string.IsNullOrWhiteSpace(request.UnitMember))
            {
                count++;
                result.Add(new NoticeUnitMemberDto
                {
                    SN = count,
                    UnitMemberOID = request.UnitMemberOID,
                    UnitMember = request.UnitMember
                });
            }

            return await Task.FromResult(result);
        }



        public async Task<List<NoticeMatterHandledByDto>> GenerateMatterHandledByAsync(
            NoticeGenerateMatterHandledByRequest request)
        {
            var result = new List<NoticeMatterHandledByDto>();
            int count = 0;

            if (request.ExistingHandlers != null &&
                request.ExistingHandlers.Count > 0)
            {
                foreach (var item in request.ExistingHandlers)
                {
                    if (request.MatterHandledByOID != item.MatterHandledByOID &&
                        request.MatterHandledBy != item.MatterHandledBy)
                    {
                        count++;
                        result.Add(new NoticeMatterHandledByDto
                        {
                            SN = count,
                            MatterHandledByOID = item.MatterHandledByOID,
                            MatterHandledBy = item.MatterHandledBy
                        });
                    }
                }
            }

            if (request.MatterHandledByOID > 0 &&
                !string.IsNullOrWhiteSpace(request.MatterHandledBy))
            {
                count++;
                result.Add(new NoticeMatterHandledByDto
                {
                    SN = count,
                    MatterHandledByOID = request.MatterHandledByOID,
                    MatterHandledBy = request.MatterHandledBy
                });
            }

            return await Task.FromResult(result);
        }


        public async Task<List<NoticePartyDto>> GeneratePartiesAsync(
           NoticeGeneratePartyRequest request)
        {
            var result = new List<NoticePartyDto>();
            int count = 0;

            if (request.ExistingParties != null &&
                request.ExistingParties.Count > 0)
            {
                foreach (var item in request.ExistingParties)
                {
                    if (request.PartyMasterOID != item.PartyMasterOID &&
                        request.CompanyName != item.CompanyName)
                    {
                        count++;
                        result.Add(new NoticePartyDto
                        {
                            SN = "Party " + count,
                            PartyMasterOID = item.PartyMasterOID,
                            CompanyName = item.CompanyName,
                            Address = item.Address
                        });
                    }
                }
            }

            if (request.PartyMasterOID > 0 &&
                !string.IsNullOrWhiteSpace(request.CompanyName))
            {
                count++;
                result.Add(new NoticePartyDto
                {
                    SN = "Party " + count,
                    PartyMasterOID = request.PartyMasterOID,
                    CompanyName = request.CompanyName,
                    Address = request.Address
                });
            }

            return await Task.FromResult(result);
        }


        public async Task<List<NoticeOppositePartyDto>> GenerateOppositePartiesAsync(
           NoticeGenerateOppositePartyRequest request)
        {
            var result = new List<NoticeOppositePartyDto>();
            int count = 0;
            bool isExisting = false;

            if (request.ExistingOppositeParties != null &&
                request.ExistingOppositeParties.Count > 0)
            {
                foreach (var item in request.ExistingOppositeParties)
                {
                    count++;
                    result.Add(new NoticeOppositePartyDto
                    {
                        SN = "Party " + count,
                        PartyMasterOID = item.PartyMasterOID,
                        CompanyName = item.CompanyName,
                        Email = item.Email,
                        Phone = item.Phone,
                        Address = item.Address,
                        ContactPerson = item.ContactPerson,
                        PanCard = item.PanCard,
                        AadhaarNo = item.AadhaarNo
                    });

                    if (request.PartyMasterOID == item.PartyMasterOID &&
                        request.PartyMaster == item.CompanyName)
                    {
                        isExisting = true;
                    }
                }
            }

            if (request.PartyMasterOID > 0 &&
                !string.IsNullOrWhiteSpace(request.PartyMaster) &&
                !isExisting)
            {
                count++;
                result.Add(new NoticeOppositePartyDto
                {
                    SN = "Party " + count,
                    PartyMasterOID = request.PartyMasterOID,
                    CompanyName = request.PartyMaster,
                    Email = request.OtherPartiesEmail,
                    Phone = request.OtherPartiesPhone,
                    Address = request.OtherPartiesAddress,
                    ContactPerson = request.OtherPartiesContactPerson,
                    PanCard = request.OtherPartiesPanCard,
                    AadhaarNo = request.OtherPartiesAadhaarNo
                });
            }

            return await Task.FromResult(result);
        }

        public async Task<List<NoticeLawFirmAdvocateDto>> GenerateAsync(
           NoticeGenerateLawFirmAdvocateRequest request)
        {
            var result = new List<NoticeLawFirmAdvocateDto>();
            int count = 0;

            if (request.ExistingLawFirmAdvocates != null &&
                request.ExistingLawFirmAdvocates.Count > 0)
            {
                foreach (var item in request.ExistingLawFirmAdvocates)
                {
                    if (request.CompanyLawFirmOID != item.CompanyLawFirmOID &&
                        request.CompanyLawFirm != item.CompanyLawFirm)
                    {
                        count++;
                        result.Add(new NoticeLawFirmAdvocateDto
                        {
                            SN = count.ToString(),
                            CompanyLawFirmOID = item.CompanyLawFirmOID,
                            CompanyLawFirm = item.CompanyLawFirm,
                            Email = item.Email,
                            Phone = item.Phone,
                            Address = item.Address,
                            ContactPerson = item.ContactPerson,
                            BarCouncilNo = item.BarCouncilNo,
                            RingiNo = item.RingiNo
                        });
                    }
                }
            }

            if (request.CompanyLawFirmOID > 0 &&
                !string.IsNullOrWhiteSpace(request.CompanyLawFirm))
            {
                count++;
                result.Add(new NoticeLawFirmAdvocateDto
                {
                    SN = count.ToString(),
                    CompanyLawFirmOID = request.CompanyLawFirmOID,
                    CompanyLawFirm = request.CompanyLawFirm,
                    Email = request.CompanyLawFirmEmailID,
                    Phone = request.CompanyLawFirmPhoneNo,
                    Address = request.CompanyLawFirmAddress,
                    ContactPerson = request.ContactPerson,
                    BarCouncilNo = request.BarCouncilNo,
                    RingiNo = request.RingiNo
                });
            }

            return await Task.FromResult(result);
        }

        public async Task<List<NoticeLawFirmAdvocateCommonDto>> GenerateAsync(
            NoticeGenerateCounterLawFirmAdvocateRequest request)
        {
            var result = new List<NoticeLawFirmAdvocateCommonDto>();
            int count = 0;
            bool isExisting = false;

            if (request.ExistingCounterLawFirms != null &&
                request.ExistingCounterLawFirms.Count > 0)
            {
                foreach (var item in request.ExistingCounterLawFirms)
                {
                    count++;
                    result.Add(new NoticeLawFirmAdvocateCommonDto
                    {
                        SN = count.ToString(),
                        LawFirmOID = item.LawFirmOID,
                        LawFirmName = item.LawFirmName,
                        Email = item.Email,
                        Phone = item.Phone,
                        Address = item.Address,
                        ContactPerson = item.ContactPerson
                    });

                    if (request.CounterLawFirmOID == item.LawFirmOID &&
                        request.CounterLawFirm == item.LawFirmName)
                    {
                        isExisting = true;
                    }
                }
            }

            if (request.CounterLawFirmOID > 0 &&
                !string.IsNullOrWhiteSpace(request.CounterLawFirm) &&
                !isExisting)
            {
                count++;
                result.Add(new NoticeLawFirmAdvocateCommonDto
                {
                    SN = count.ToString(),
                    LawFirmOID = request.CounterLawFirmOID,
                    LawFirmName = request.CounterLawFirm,
                    Email = request.CounterLawFirmEmailID,
                    Phone = request.CounterLawFirmPhoneNo,
                    Address = request.CounterLawFirmAddress,
                    ContactPerson = request.CounterLawFirmContactPerson
                });
            }

            return await Task.FromResult(result);
        }
    
}
}