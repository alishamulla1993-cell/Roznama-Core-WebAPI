using Microsoft.Data.SqlClient;
using Roznama.Models.Litigation;
using Roznama.Models.Litigation.Models;
using Roznama.Modules.Common;
using Roznama.Modules.Notice;
using Roznama.Common.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roznama.Models.Litigation
{
    public class LitigationService
    {
        private readonly DropdownRepository _dropdownRepo;
        private readonly LitigationRepository _repo;
        private readonly IHttpContextAccessor _httpContext;

        public LitigationService(DropdownRepository dropdownRepo, LitigationRepository repo, IHttpContextAccessor httpContext)
        {
            _dropdownRepo = dropdownRepo;
            _repo = repo;
            _httpContext = httpContext;
        }
        #region Add LitigationPage

        public Task<IEnumerable<dynamic>> GetNoticeDetailsByNoticeOID(int NoticeOID)
=> _repo.GetNoticeDetailsByNoticeOID(NoticeOID);

        public Task<IEnumerable<dynamic>> GetLitigationID(int LitigationOID)
=> _repo.GetLitigationID(LitigationOID);

        public Task<IEnumerable<dynamic>> GetMSILFileNo(string LitigationID)
=> _repo.GetMSILFileNo(LitigationID);

        public Task<IEnumerable<dynamic>> GetCourtCaseTitle(int LitigationOID)
=> _repo.GetCourtCaseTitle(LitigationOID);

        public Task<IEnumerable<dynamic>> GetLitigationAllDetailbyLitigationOID(int LitigationOID)
=> _repo.GetLitigationAllDetailbyLitigationOID(LitigationOID);

        public Task<IEnumerable<dynamic>> GetCompanyAdvocateDetails(int LitigationOID)
=> _repo.GetCompanyAdvocateDetails(LitigationOID);

        public Task<IEnumerable<dynamic>> GetSubcourt(int Courttype)
=> _repo.GetSubcourt(Courttype);

        public Task<IEnumerable<dynamic>> GetAllCourtType(string DigitizedOrNonDigitized)
=> _repo.GetAllCourtType(DigitizedOrNonDigitized);

public async Task<IEnumerable<StateDto>> GetStatesAsync(
        int courtTypeOID)
        {
            return await _repo.GetStatesByCourtTypeAsync(courtTypeOID);
        }

        public Task<IEnumerable<dynamic>> GetCasewiseCrawlerSpGetConsumerState()
=> _repo.GetCasewiseCrawlerSpGetConsumerState();

        public Task<IEnumerable<dynamic>> GetAllDistrict(int StateOID)
=> _repo.GetAllDistrict(StateOID);

        public Task<IEnumerable<dynamic>> GetBench(int intCourtType, string CourtSubType, int state, int district, int CourtComplex)
=> _repo.GetBench( intCourtType,  CourtSubType,  state,  district,  CourtComplex);

        public Task<IEnumerable<dynamic>> GetCaseTypeData(int intCourtType, string CourtSubType, int state, int district, int CourtComplex, string CourtValueField)
=> _repo.GetCaseTypeData(intCourtType, CourtSubType, state, district, CourtComplex,  CourtValueField);

        public Task<IEnumerable<dynamic>> GetNonDigitizeCourtMaster()
=> _repo.GetNonDigitizeCourtMaster();
        public Task<IEnumerable<dynamic>> GetNonDigitizeCaseTypeMaster()
=> _repo.GetNonDigitizeCaseTypeMaster();
        public Task<IEnumerable<dynamic>> GetAllUnderAct()
=> _repo.GetAllUnderAct();
        public Task<IEnumerable<dynamic>> GetAllSubjectMatter()
=> _repo.GetAllSubjectMatter();
        public Task<IEnumerable<dynamic>> GetAllCaseTypeTribunal(int courttypeoid, int stateoid, int TribunalOID)
=> _repo.GetAllCaseTypeTribunal( courttypeoid,  stateoid,  TribunalOID);

        public Task<IEnumerable<dynamic>> GetAllCaseType(int courttypeoid, int stateoid)
=> _repo.GetAllCaseType(courttypeoid, stateoid);

        public Task<IEnumerable<dynamic>> GetAllCaseTypeConsumer(int courttypeoid, int stateoid,int ConsumerOID)
=> _repo.GetAllCaseTypeConsumer(courttypeoid, stateoid, ConsumerOID);
        public Task<IEnumerable<dynamic>> GetNameoftheConsumer()
=> _repo.GetNameoftheConsumer();
        public Task<IEnumerable<dynamic>> GetNameoftheLabourCourt()
=> _repo.GetNameoftheLabourCourt();
        public Task<IEnumerable<dynamic>> GetNameoftheTribunal()
=> _repo.GetNameoftheTribunal();
        public Task<IEnumerable<dynamic>> GetMSILCaseType()
=> _repo.GetMSILCaseType();

        public async Task<IEnumerable<dynamic>> GetLinkedLitigation(
        int litigationOID)
        {
            int userOID = _httpContext.HttpContext.GetUserOID();

            return await _repo.GetLinkedLitigation(
                litigationOID, userOID);
        }
        public Task<IEnumerable<dynamic>> GetArbitrationOID()
=> _repo.GetArbitrationOID();

        public Task<IEnumerable<dynamic>> GetMasterDetailData(string Type)
=> _repo.GetMasterDetailData(Type);
        public Task<IEnumerable<dynamic>> GetMasterDetailDataDealer()
=> _repo.GetMasterDetailDataDealer();
        public Task<IEnumerable<dynamic>> GetAllStages()
=> _repo.GetAllStages();

        public Task<IEnumerable<dynamic>> GetCourtName(int intCourtType, int intState, int intDistrictOID, int intTribunalOID)
=> _repo.GetCourtName( intCourtType,  intState,  intDistrictOID,  intTribunalOID);
        public async Task<bool> IsDuplicateCaseNumberAsync(
       DuplicateCaseCheckRequest request)
        {
            // ✅ Null / empty validation
            if (string.IsNullOrWhiteSpace(request.CaseNumber))
                return false; // treat empty as NOT duplicate

            int result = await _repo.CheckDuplicateCaseNumberAsync(
                request.LitigationOID,
                request.CaseNumber.Trim(),
                request.CourtOID,
                request.CaseTypeOID);

            return result == 1;
        }
        public Task<IEnumerable<dynamic>> GetDirectorPromoterName(int UnitOID)
=> _repo.GetDirectorPromoterName(UnitOID);
        public async Task<PartyDetailsDto?> GetPartyDetailsAsync(
        int partyTypeOID,
        string partyName)
        {
            if (string.IsNullOrWhiteSpace(partyName))
                return null;

            var parties =
                await _repo.GetPartySummaryAsync(partyTypeOID);

            var party = parties.FirstOrDefault(p =>
    string.Equals(
        p.PartyName,
        partyName,
        StringComparison.OrdinalIgnoreCase));

            if (party == null)
                return null;

            var contacts =
                await _repo.GetPartyContactsAsync(party.PartyMasterOID);

            party.Contacts = contacts.ToList();

            return party;
        }
        public Task<IEnumerable<dynamic>> GetSubUnitDetail()
=> _repo.GetSubUnitDetail();

        public async Task<PartyOtherDetailsDto?> GetOtherPartyDetailsAsync(
        int partyTypeOID,
        string partyName)
        {
            if (string.IsNullOrWhiteSpace(partyName))
                return null;

            var parties =
                await _repo.GetPartySummaryOtherDetailAsync(partyTypeOID);

            var party = parties.FirstOrDefault(p =>
                string.Equals(
                    p.PartyName,
                    partyName,
                    StringComparison.OrdinalIgnoreCase));

            if (party == null)
                return null;

            party.PartyTypeOID = partyTypeOID;
            return party;
        }
        public Task<IEnumerable<dynamic>> GetCounterType(string companyType,int classificationTypeOID,int litigationCategoryOID)
=> _repo.GetCounterType( companyType,classificationTypeOID, litigationCategoryOID);
        public Task<IEnumerable<dynamic>> GetSubCategory(int litigationCategoryOID)
=> _repo.GetSubCategory(litigationCategoryOID);

        public Task<IEnumerable<dynamic>> GetBombayCaseTypeData(int intCourtType, string CourtSubType, string CourtValueField,string stamp,string side)
=> _repo.GetBombayCaseTypeData(intCourtType, CourtSubType, CourtValueField,stamp,side);

        public async Task<int> GetPartyMasterOIDAsync(
        int partyTypeOID,
        string partyName)
        {
            if (partyTypeOID <= 0)
                throw new ArgumentException("Invalid PartyTypeOID");

            if (string.IsNullOrWhiteSpace(partyName))
                throw new ArgumentException("PartyName is required");

            return await _repo.GetPartyMasterOIDAsync(
                partyTypeOID,
                partyName.Trim());
        }
        public Task<IEnumerable<dynamic>> GetLitigationforOppositeParty(string PartyName)
=> _repo.GetLitigationforOppositeParty(PartyName);
        public Task<IEnumerable<dynamic>> GetRiskDetail()
=> _repo.GetRiskDetail();
        public Task<IEnumerable<dynamic>> GetClientDetails(int LitigationOID)
=> _repo.GetClientDetails(LitigationOID);
        
        /// <summary>
        /// Post Method Start
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<UnitMemberDto>> GenerateUnitMembersAsync(
    GenerateUnitMemberRequest request)
        {
            var result = new List<UnitMemberDto>();
            int count = 0;

            if (request.ExistingMembers != null && request.ExistingMembers.Count > 0)
            {
                foreach (var item in request.ExistingMembers)
                {
                    if (request.UnitMemberOID != item.UnitMemberOID &&
                        request.UnitMember != item.UnitMember)
                    {
                        count++;
                        result.Add(new UnitMemberDto
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
                result.Add(new UnitMemberDto
                {
                    SN = count,
                    UnitMemberOID = request.UnitMemberOID,
                    UnitMember = request.UnitMember
                });
            }

            return await Task.FromResult(result);
        }



        public async Task<List<MatterHandledByDto>> GenerateMatterHandledByAsync(
            GenerateMatterHandledByRequest request)
        {
            var result = new List<MatterHandledByDto>();
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
                        result.Add(new MatterHandledByDto
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
                result.Add(new MatterHandledByDto
                {
                    SN = count,
                    MatterHandledByOID = request.MatterHandledByOID,
                    MatterHandledBy = request.MatterHandledBy
                });
            }

            return await Task.FromResult(result);
        }


        public async Task<List<PartyDto>> GeneratePartiesAsync(
           GeneratePartyRequest request)
        {
            var result = new List<PartyDto>();
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
                        result.Add(new PartyDto
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
                result.Add(new PartyDto
                {
                    SN = "Party " + count,
                    PartyMasterOID = request.PartyMasterOID,
                    CompanyName = request.CompanyName,
                    Address = request.Address
                });
            }

            return await Task.FromResult(result);
        }


        public async Task<List<OppositePartyDto>> GenerateOppositePartiesAsync(
           GenerateOppositePartyRequest request)
        {
            var result = new List<OppositePartyDto>();
            int count = 0;
            bool isExisting = false;

            if (request.ExistingOppositeParties != null &&
                request.ExistingOppositeParties.Count > 0)
            {
                foreach (var item in request.ExistingOppositeParties)
                {
                    count++;
                    result.Add(new OppositePartyDto
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
                result.Add(new OppositePartyDto
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

        public async Task<List<LawFirmAdvocateDto>> GenerateAsync(
           GenerateLawFirmAdvocateRequest request)
        {
            var result = new List<LawFirmAdvocateDto>();
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
                        result.Add(new LawFirmAdvocateDto
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
                result.Add(new LawFirmAdvocateDto
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

        public async Task<List<LawFirmAdvocateCommonDto>> GenerateAsync(
            GenerateCounterLawFirmAdvocateRequest request)
        {
            var result = new List<LawFirmAdvocateCommonDto>();
            int count = 0;
            bool isExisting = false;

            if (request.ExistingCounterLawFirms != null &&
                request.ExistingCounterLawFirms.Count > 0)
            {
                foreach (var item in request.ExistingCounterLawFirms)
                {
                    count++;
                    result.Add(new LawFirmAdvocateCommonDto
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
                result.Add(new LawFirmAdvocateCommonDto
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

        public async Task<List<SubCategoryDto>> GenerateSubCategoryAsync(
        GenerateSubCategoryRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await _repo.GenerateSubCategoryAsync(request);
        }
        //Under ACt
        public async Task<List<UnderActDto>> AddUnderActAsync(
       AddUnderActRequest request)
        {
            int underActOID = 0;
            string underActName = request.UnderActName?.Trim() ?? "";

            // Case 1: Existing Under Act selected
            if (request.UnderActOID > 0)
            {
                underActOID = request.UnderActOID;
            }
            // Case 2: Other Under Act selected (OID = 0)
            else if (request.UnderActOID == 0 &&
                     !string.IsNullOrWhiteSpace(underActName))
            {
                underActOID =
                    await _repo.InsertNewUnderActAsync(underActName);

                // 🔹 Transaction log (same as Web Forms)
                int userId = _httpContext.HttpContext.GetUserOID();

                // call your logging method here if needed
            }

            // Generate updated UnderAct list (API version of generateTable_UnderAct)
            var result = new List<UnderActDto>();
            int count = 0;

            if (request.ExistingUnderActs != null)
            {
                foreach (var item in request.ExistingUnderActs)
                {
                    if (item.UnderActOID != underActOID)
                    {
                        count++;
                        result.Add(new UnderActDto
                        {
                            SN = count,
                            UnderActOID = item.UnderActOID,
                            UnderAct = item.UnderAct
                        });
                    }
                }
            }

            if (underActOID > 0 && !string.IsNullOrEmpty(underActName))
            {
                count++;
                result.Add(new UnderActDto
                {
                    SN = count,
                    UnderActOID = underActOID,
                    UnderAct = underActName
                });
            }

            return result;
        }
        public async Task<int> InsertOtherUnderAct(string UndersActName)
        {
            return await _repo.InsertSubjectMatterAsync(
                UndersActName.Trim());
        }
        public async Task<int> AddSubjectMatterAsync(string subjectMatterName)
        {
            return await _repo.InsertSubjectMatterAsync(
                subjectMatterName.Trim());
        }
        public async Task<int> AddStageAsync(string stageName)
        {
            int caseTypeStageOID =
                await _repo.InsertStageAsync(stageName.Trim());

            if (caseTypeStageOID > 0)
            {
                int userId = _httpContext.HttpContext.GetUserOID();
            }

            return caseTypeStageOID;
        }
        public async Task<DiscoverySelectionResponse> SaveDiscoveryAsync(
       DiscoverySelectionRequest request)
        {
            int caseWiseOID = await _repo.SaveDiscoveryAsync(request);

            return new DiscoverySelectionResponse
            {
                CaseWiseOID = caseWiseOID,
                Success = caseWiseOID > 0
            };
        }
        public async Task<ResponseDto> InsertLitigationPartiesAsync(
        List<UpdateClientContactRequest> parties)
        {
            if (parties == null || parties.Count == 0)
                return new ResponseDto { Success = false };

            int insertedCount = 0;

            foreach (var party in parties)
            {
                if (party.PartyMasterOID <= 0 || party.LitigationOID <= 0)
                    continue;

                int result = await _repo.InsertLitigationPartyAsync(
                    party.PartyMasterOID,
                    party.LitigationOID);

                if (result > 0)
                    insertedCount++;
            }

            return new ResponseDto
            {
                Success = insertedCount > 0,
                RowsAffected = insertedCount
            };
        }

        public async Task<int> SaveOppositePartiesAsync(
     OppositePartiesRequest request)
        {
            if (request == null ||
                request.Parties == null ||
                request.Parties.Count == 0)
                return 0;

            int result = 0;

            foreach (var party in request.Parties)
            {
                // 1️⃣ Insert Litigation Parties
                await _repo.InsertLitigationPartyAsync(
                    party.PartyMasterOID,
                    request.LitigationOID
                );

                // 2️⃣ Insert Opposite Party Contact Details
                result = await _repo.InsertOppositePartyContactAsync(
                    party,
                    request.LitigationOID
                );
            }

            return result; // last execution result
        }

        public async Task<int> SaveCompanyLawFirmAdvocatesAsync(
    CompanyLawFirmAdvocateRequest request)
        {
            if (request == null || request.Advocates == null || !request.Advocates.Any())
                return 0;

            int result = 0;

            foreach (var advocate in request.Advocates)
            {
                // 1️⃣ Insert Litigation Party
                await _repo.InsertLitigationPartyAsync(
                    advocate.PartyMasterOID,
                    request.LitigationOID
                );

                // 2️⃣ Insert Lawyer Contact Detail
                result = await _repo.InsertCompanyLawyerContactAsync(
                    advocate,
                    request.LitigationOID
                );
            }

            return result; // last insert result
        }

        public async Task<int> SaveCounterLawFirmsAsync(
      CounterLawFirmRequest request)
        {
            if (request == null ||
                request.CounterLawFirms == null ||
                request.CounterLawFirms.Count == 0)
                return 0;

            int result = 0;

            foreach (var firm in request.CounterLawFirms)
            {
                // 1️⃣ Insert into LitigationParties
                await _repo.InsertLitigationPartyAsync(
                    firm.PartyMasterOID,
                    request.LitigationOID
                );

                // 2️⃣ Insert Counter Lawyer Contact Detail
                result = await _repo.InsertCounterLawyerContactAsync(
                    firm,
                    request.LitigationOID
                );
            }

            return result; // last execution result
        }

        public async Task<InsertLitigationOrgResponse> CreateLitigationAsync(
    InsertLitigationOrgRequest request)
        {
            return await _repo.InsertLitigationOrgDetailAsync(request);
        }
        public async Task<int> InsertHandledByAsync(LitigationHandledByRequest request)
        {
            // 1️⃣ Request null check
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null");

            // 2️⃣ LitigationOID validation
            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            // 3️⃣ UserOIDs null / empty check
            if (request.UserOIDs == null || !request.UserOIDs.Any())
                throw new ArgumentException("UserOIDs list cannot be null or empty");

            int result = 0;

            // 4️⃣ Loop with per-item validation
            foreach (var userOID in request.UserOIDs)
            {
                if (userOID <= 0)
                    continue; // skip invalid user IDs safely

                result = await _repo.InsertLitigationHandledByAsync(
                    userOID,
                    request.LitigationOID);
            }

            return result; // last execution result
        }
        public async Task<int> InsertUnitMembersAsync(
        LitigationHandledByRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.UserOIDs == null || !request.UserOIDs.Any())
                throw new ArgumentException("User list cannot be empty");

            int result = 0;

            foreach (var userOID in request.UserOIDs)
            {
                if (userOID <= 0)
                    continue;

                result = await _repo.InsertUnitMemberAsync(
                    userOID,
                    request.LitigationOID);
            }

            return result; // last insert result
        }
        public async Task<int> SavePoaDocumentsAsync(
      LitigationPoaDocumentsRequest request)
        {
            // 🔹 Request-level validation
            if (request == null)
                return 0;

            if (request.LitigationOID <= 0 || request.UserId <= 0)
                return 0;

            if (request.Documents == null || request.Documents.Count == 0)
                return 0;

            int result = 0;

            foreach (var doc in request.Documents)
            {
                // 🔹 Per-document validation
                if (doc == null)
                    continue;

                if (doc.Filebyte == null || doc.Filebyte.Length == 0)
                    continue;

                if (string.IsNullOrWhiteSpace(doc.FileName))
                    continue;

                // FileSize fallback (optional safety)
                long fileSize = doc.FileSize > 0
                    ? doc.FileSize
                    : doc.Filebyte.Length;

                result = await _repo.InsertPoaDocumentAsync(
                    request.LitigationOID,
                    request.UserId,
                    doc.Filebyte,
                    doc.FileName.Trim(),
                    fileSize,
                    "POABRLOA",                // fixed
                    string.Empty,              // description empty
                    doc.ReferenceOwnerName?.Trim() ?? string.Empty
                );
            }

            return result; // last successful insert result
        }
        public async Task<int> AddSubCategoryAsync(
     int litigationOID,
     int subCategoryOID)
        {
            if (litigationOID <= 0 || subCategoryOID <= 0)
                return 0;

            return await _repo.InsertSubCategoryAsync(
                litigationOID,
                subCategoryOID);
        }

        public async Task<int> InsertDirectorName(
   string PartyName)
        {
            if (PartyName == null )
                return 0;

            return await _repo.InsertDirectorName(
                PartyName);
        }
        public async Task<int> InsertLitigationCaseDetailsAsync(
       LitigationEntity_Roznama e,
       int litigationOID)
        {
            // 🔹 Basic validation
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (litigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (string.IsNullOrWhiteSpace(e.Casenumber))
                throw new ArgumentException("Case number is required");

            // 🔹 Call repository
            int result = await _repo.InsertLitigationCaseDetailsAsync(
                e,
                litigationOID);

            // 🔹 Business rule check
            if (result <= 0)
                throw new ApplicationException(
                    "Failed to insert litigation case details");

            return result;
        }

        public async Task<int> InsertConnectedNotice(
    int litigationOID,
    int NoticeOID)
        {
            if (litigationOID <= 0 || NoticeOID <= 0)
                return 0;

            return await _repo.InsertConnectedNotice(
                litigationOID,
                NoticeOID);
        }

        public async Task InsertConnectedLitigationAsync(
        InsertConnectedLitigationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.ConnectedLitigationOID <= 0)
                throw new ArgumentException("Invalid Connected LitigationOID");

            if (request.LitigationOID == request.ConnectedLitigationOID)
                throw new ArgumentException("Litigation cannot be connected to itself");

            int result = await _repo.InsertConnectedLitigation(
                request.LitigationOID,
                request.ConnectedLitigationOID);

            if (result <= 0)
                throw new ApplicationException(
                    "Failed to insert connected litigation");
        }

        public async Task InsertConnectedArbitrationAsync(
        InsertConnectedArbitrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.ArbitrationOID <= 0)
                throw new ArgumentException("Invalid ArbitrationOID");

            if (request.IsConnected != 0 && request.IsConnected != 1)
                throw new ArgumentException("IsConnected must be 0 or 1");

            int result = await _repo.InsertConnectedArbitrationAsync(
                request.LitigationOID,
                request.ArbitrationOID,
                request.IsConnected);

            if (result <= 0)
                throw new ApplicationException(
                    "Failed to insert connected arbitration");
        }

        public async Task<int> InsertOtherPartyLawFirmAsync(
        int partyTypeOID,
        string partyName)
        {
            if (partyTypeOID <= 0)
                throw new ArgumentException("Invalid PartyTypeOID");

            if (string.IsNullOrWhiteSpace(partyName))
                throw new ArgumentException("Party name is required");

          

            int partyMasterOID =
                await _repo.InsertOtherPartyLawFirmAsync(partyTypeOID, partyName);

            if (partyMasterOID <= 0)
                throw new ApplicationException(
                    "Failed to insert party / law firm");

            return partyMasterOID;
        }
        public async Task<int> InsertNewCompanyLawFirmAsync(
          LawFirmAdvocateDto dto)
        {
            // 🔹 Validation
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.CompanyLawFirm))
                throw new ArgumentException("Company Law Firm name is required");

            // 🔹 Insert
            int companyLawFirmOID =
                await _repo.InsertNewCompanyLawFirmAsync(dto);

            // 🔹 Business validation
            if (companyLawFirmOID <= 0)
                throw new ApplicationException(
                    "Failed to insert Company Law Firm");

            // 🔹 Audit / Log
            int userId = Convert.ToInt32(
                _httpContext.HttpContext?.Session.GetInt32("RUSEROID") ?? 0);

           

            return companyLawFirmOID;
        }
        public async Task<int> InsertPartiesAsync(InsertPartyRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.PartyName))
                throw new ArgumentException("Party name is required");

            int partyMasterOID = await _repo.InsertPartiesAsync(
                request.PartyName.Trim(),
                request.ClientCode,
                request.IsClient
            );

            if (partyMasterOID <= 0)
                throw new ApplicationException("Failed to insert party");

            return partyMasterOID;
        }

        public async Task<bool> InsertMailLogAsync(InsertMailLogRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.ToEmailID))
                throw new ArgumentException("ToEmailID is required");

            if (string.IsNullOrWhiteSpace(request.Subject))
                throw new ArgumentException("Subject is required");

            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ArgumentException("Message is required");

            request.CCEmailID ??= string.Empty;
            request.BCCemailID ??= string.Empty;
            request.ContentType ??= "HTML";
            request.Status = request.Status == '\0' ? 'N' : request.Status;

            var result = await _repo.InsertMailLogAsync(request);

            return result;
        }

        public async Task<bool> InsertConnectedLitigationToTaxAsync(
        InsertConnectedLitigationToTaxRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.TaxOID <= 0)
                throw new ArgumentException("Invalid TaxOID");

            if (string.IsNullOrWhiteSpace(request.TaxType))
                throw new ArgumentException("TaxType is required");

            int result = await _repo.InsertConnectedLitigationToTaxAsync(
                request.LitigationOID,
                request.TaxOID,
                request.TaxType
            );

            return result > 0;
        }

        public async Task<bool> InsertTransactionLogAsync(
       InsertTransactionLogRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.LogType))
                throw new ArgumentException("LogType is required");

            if (string.IsNullOrWhiteSpace(request.LogDesc))
                throw new ArgumentException("LogDesc is required");

            if (request.UserId <= 0)
                throw new ArgumentException("Invalid UserId");

            int result = await _repo.InsertTransactionLogAsync(
                request.LogType,
                request.LogDesc,
                request.UserId,
                request.MasterOID
            );

            return result > 0;
        }

        public Task<int> InsertWitnessMaster( WitnessDto model)
    => _repo.InsertWitnessMaster(model);
        /// <summary>
        /// Delete Method Start
        /// </summary>
        /// <param name="litigationOID"></param>
        /// <returns></returns>
        public async Task<ResponseDto> DeleteCompanyPartiesAsync(int litigationOID)
        {
            int rows = await _repo.DeleteCompanyPartiesAsync(litigationOID);

            return new ResponseDto
            {
                Success = rows > 0,
                RowsAffected = rows
            };
        }
        public async Task<bool> DeleteMatterHandledByAsync(int litigationOID)
        {
            int result = await _repo.DeleteMatterHandledByAsync(litigationOID);
            return result > 0;
        }
        public async Task<int> DeleteUnitMembersAsync(int litigationOID)
        {
            if (litigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            return await _repo.DeleteUnitMembersAsync(litigationOID);
        }

        public async Task<int> DeleteUnderAct(int litigationOID)
        {
            if (litigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            return await _repo.DeleteUnderAct(litigationOID);
        }
        public async Task<List<LawFirmAdvocateDto>> DeleteLawFirmAdvocateAsync(
    DeleteLawFirmAdvocateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var updatedList = _repo.DeleteLawFirmAdvocate(
                request.CompanyLawFirmOID,
                request.CompanyLawFirm,
                request.ExistingLawFirmAdvocates
            );

            return await Task.FromResult(updatedList);
        }

        public async Task<List<LawFirmAdvocateDto>> DeleteCounterLawFirmAsync(
         DeleteCounterLawFirmRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var updatedList = _repo.DeleteCounterLawFirm(
                request.CounterLawFirmOID,
                request.CounterLawFirm,
                request.ExistingCounterLawFirms
            );

            return await Task.FromResult(updatedList);
        }
        public async Task<List<SubCategoryDto>> DeleteSubCategoryAsync(
        DeleteSubCategoryRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await _repo.DeleteSubCategoryAsync(request);
        }
        public Task<IEnumerable<dynamic>> DeleteLitigationHearing(int LitigationHearingOID)
=> _repo.DeleteLitigationHearing(LitigationHearingOID);

        public Task<IEnumerable<dynamic>> DeletePowerOfAttorneyDocument(int DocOID)
=> _repo.DeletePowerOfAttorneyDocument(DocOID);

        public Task<IEnumerable<dynamic>> DeleteBilling(int BillingOID)
=> _repo.DeleteBilling(BillingOID);

        public Task<IEnumerable<dynamic>> DeleteWitness(int WitnessOID)
=> _repo.DeleteWitness(WitnessOID);
        public Task<IEnumerable<dynamic>> deletelitigatiotaskdocument(int DocOID)
=> _repo.deletelitigatiotaskdocument(DocOID);
        /// <summary>
        /// Update Method start
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateClientContactAsync(
        UpdateClientContactRequest request)
        {
            if (request.PartyMasterOID <= 0 || request.LitigationOID <= 0)
            {
                return new ResponseDto
                {
                    Success = false,
                    RowsAffected = 0
                };
            }

            int rows = await _repo.UpdateClientContactAsync(
                request.PartyMasterOID,
                request.LitigationOID);

            return new ResponseDto
            {
                Success = rows > 0,
                RowsAffected = rows
            };
        }
        public async Task<bool> UpdateLitigationDetailsAsync(UpdateLitigationDetailsRequest request)
        {
            int result = await _repo.UpdateLitigationDetailsAsync(request);
            return result > 0;
        }
        public async Task<bool> UpdateFinalStatus(string Status,int LitigationOID)
        {
            int result = await _repo.UpdateFinalStatus(Status,LitigationOID);
            return result > 0;
        }
        #endregion
        #region Litigation Details Page API's
        #region Get Litigation details page api
        public Task<IEnumerable<dynamic>> GetLitigationDetailbyLitigationOID(int LitigationOID)
=> _repo.GetLitigationDetailbyLitigationOID(LitigationOID);
        public Task<IEnumerable<dynamic>> GetConfidentialTypeApplicable(int UnitOID)
=> _repo.GetConfidentialTypeApplicable(UnitOID);
        public Task<IEnumerable<dynamic>> GetLitigationVehicleDealerDetails(int LitigationOID)
=> _repo.GetLitigationVehicleDealerDetails(LitigationOID);

        public Task<IEnumerable<dynamic>> GetLitigationLabourDetails(int LitigationOID)
=> _repo.GetLitigationLabourDetails(LitigationOID);
        public Task<IEnumerable<dynamic>> CheckBucketListForLitigation(int UserOID, int intLitigationOID, int intEntity, int intUnit)
=> _repo.CheckBucketListForLitigation(UserOID, intLitigationOID,  intEntity,  intUnit);

        public Task<LitigationEntity_Roznama> GetPowerOfAttorneyDocumentByDOCOID(int docID)
    => _repo.GetPowerOfAttorneyDocumentByDOCOID(docID);
        public Task<IEnumerable<dynamic>> GetLitigationStageSummary(int LitigationOID)
=> _repo.GetLitigationStageSummary(LitigationOID);
        public Task<IEnumerable<dynamic>> GetPartiesByLitigationAndPartyType(int LitigationOID,int PartyTypeOID)
=> _repo.GetPartiesByLitigationAndPartyType(LitigationOID,PartyTypeOID);
        public Task<IEnumerable<dynamic>> GetBillTypesForLitigation()
=> _repo.GetBillTypesForLitigation();
        public Task<IEnumerable<dynamic>> GetLitigationStageHearingDates(int LitigationOID)
=> _repo.GetLitigationStageHearingDates(LitigationOID);
        public Task<IEnumerable<dynamic>> GetLitigationBillingSummary(int LitigationOID)
=> _repo.GetLitigationBillingSummary(LitigationOID);
        public Task<IEnumerable<dynamic>> GetWitness(int LitigationOID)
=> _repo.GetWitness(LitigationOID);
        public Task<LitigationAlertDto> GetAlertforLitigation(int litigationOID)
    => _repo.GetAlertforLitigation(litigationOID);
        public Task<string> GetFromMailID()
    => _repo.GetFromMailID();
        public Task<string> GetApplicationLink()
    => _repo.GetApplicationLink();
        public Task<IEnumerable<dynamic>> GetLitigationResultMaster()
=> _repo.GetLitigationResultMaster();
        public Task<IEnumerable<dynamic>> GetNoticesforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID, string txtsearch)
=> _repo.GetNoticesforConnectedLitigation(LitigationOID, CurrentLitigaionOID,UserOID,txtsearch);
        public Task<IEnumerable<dynamic>> GetLitigationforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID, string txtsearch)
       => _repo.GetLitigationforConnectedLitigation(LitigationOID, CurrentLitigaionOID, UserOID, txtsearch);
        public Task<IEnumerable<dynamic>> GetArbitrationsforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID, string txtsearch)
   => _repo.GetArbitrationsforConnectedLitigation(LitigationOID, CurrentLitigaionOID, UserOID, txtsearch);
        public Task<IEnumerable<dynamic>> GetLitigationDocuments(int MasterOID, string DocType)
=> _repo.GetLitigationDocuments( MasterOID,  DocType);

        public Task<IEnumerable<dynamic>> BindPartyEmail(int LitigationOID)
=> _repo.BindPartyEmail(LitigationOID);
        public Task<IEnumerable<dynamic>> GetResponsiblePerson(int LitigationOID,int ArbitrationOID)
=> _repo.GetResponsiblePerson(LitigationOID, ArbitrationOID);
        public Task<IEnumerable<dynamic>> GetLitigationDocumentsforDetails(int GeneralHearingOID, string DocType)
=> _repo.GetLitigationDocumentsforDetails( GeneralHearingOID,  DocType);
        public Task<IEnumerable<dynamic>> GetLitigationActivityLog(int LitigationOID)
=> _repo.GetLitigationActivityLog(LitigationOID);
        public Task<IEnumerable<dynamic>> GetLibraryTypes()
=> _repo.GetLibraryTypes();
        public Task<IEnumerable<dynamic>> GetAllEntitiesByUser(int UserOID)
=> _repo.GetAllEntitiesByUser(UserOID);

        public Task<IEnumerable<dynamic>> GetCaseBackground(int LitigationOID)
=> _repo.GetCaseBackground(LitigationOID);

        public Task<IEnumerable<dynamic>> GetAllInterimProceeding(int LitigationOID)
=> _repo.GetAllInterimProceeding(LitigationOID);
        public Task<IEnumerable<dynamic>> GetAllInterimAppeal(int LitigationOID)
=> _repo.GetAllInterimAppeal(LitigationOID);

        public Task<IEnumerable<dynamic>> GeteReferenceLibraryForLitigations(int LitigationOID, int CurrentLitigaionOID)
=> _repo.GeteReferenceLibraryForLitigations(LitigationOID, CurrentLitigaionOID);

        public Task<BillingDetailsDto> GetLitigationBillingDetailsForUpdate(int billingOID)
    => _repo.GetLitigationBillingDetailsForUpdate(billingOID);
        public Task<List<PartyContactDto>> GetPartyContacts(int partyMasterOID)
    => _repo.GetPartyContacts(partyMasterOID);
        public Task<IEnumerable<dynamic>> GetChequeforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID,int UserOID)
=> _repo.GetChequeforConnectedLitigation(LitigationOID, CurrentLitigaionOID,UserOID);
        public Task<LitigationAlertEmailDto> GetLitigationForAlertEmailbyLitigationOID(int litigationOID)
    => _repo.GetLitigationForAlertEmailbyLitigationOID(litigationOID);
        public Task<string> GetUserEmailID(int preparatoryOID)
    => _repo.GetUserEmailID(preparatoryOID);
        public Task<string> GetUserName(int preparatoryOID)
    => _repo.GetUserName(preparatoryOID);
        public Task<IEnumerable<dynamic>> GetMaterialChangeCommunication(int LitigationOID)
=> _repo.GetMaterialChangeCommunication(LitigationOID);
        public Task<IEnumerable<dynamic>> GetREMforConnectedLitigation(int LitigationOID, int CurrentLitigaionOID, int UserOID)
=> _repo.GetREMforConnectedLitigation(LitigationOID,  CurrentLitigaionOID, UserOID);
        public Task<IEnumerable<dynamic>> Ifalreadytaskowner(int LitigationOID, int UserOID)
=> _repo.Ifalreadytaskowner(LitigationOID, UserOID);
        public Task<string> GetLawFirmAdvocateUserEmailID(int preparatoryOID)
    => _repo.GetLawFirmAdvocateUserEmailID(preparatoryOID);
        public Task<IEnumerable<dynamic>> GetLitigationTaskBylitigationid(int LitigationOID, int UserOID)
=> _repo.GetLitigationTaskBylitigationid(LitigationOID, UserOID);

        #endregion
        /// <summary>
        /// Post Method Litigation Details
        /// </summary>
        /// <returns></returns>
        #region Post Method Litigation Details
        public async Task<bool> CheckValidHearingDateAsync(
        CheckHearingDateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.NextHearingDate == DateTime.MinValue)
                throw new ArgumentException("Invalid Hearing Date");

            return await _repo.CheckValidHearingDateAsync(
                request.LitigationOID,
                request.NextHearingDate
            );
        }
        public async Task<(int result, int hearingStageOID)>
        InsertCaseTypeStageAsync(InsertCaseTypeStageRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            if (request.CaseStageOID <= 0)
                throw new ArgumentException("Invalid Case Stage");

            var response =
                await _repo.InsertCaseTypeStageAsync(request);

            if (response.rowsAffected <= 0)
                throw new ApplicationException("Insert failed");

            return response;
        }
        public async Task<int> InsertLitigationActionItemsAsync(
        InsertLitigationActionItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LigationHearingStageOID <= 0)
                throw new ArgumentException("Invalid Hearing Stage OID");

            if (request.CreatedByOID <= 0)
                throw new ArgumentException("Invalid CreatedByOID");

            if (request.ActionItems == null || !request.ActionItems.Any())
                throw new ArgumentException("No action items provided");

            return await _repo.InsertLitigationActionItemsAsync(
                request.ActionItems,
                request.LigationHearingStageOID,
                request.CreatedByOID
            );
        }
        public async Task<int> InsertLitigationStageDocumentsAsync(
        InsertLitigationStageDocumentsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LigationStageHearingOID <= 0)
                throw new ArgumentException("Invalid Stage Hearing OID");

            if (request.UserId <= 0)
                throw new ArgumentException("Invalid UserId");

            if (request.Documents == null || !request.Documents.Any())
                throw new ArgumentException("No documents provided");

            return await _repo.InsertLitigationStageDocumentsAsync(
                request.Documents,
                request.LigationStageHearingOID,
                request.UserId
            );
        }

        public async Task<int> UploadLibraryDocumentAsync(
       InsertLibraryDocumentRequest request)
        {
            // 🔹 Validation
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Filebyte == null || request.Filebyte.Length == 0)
                throw new ArgumentException("File data is required");

            if (string.IsNullOrWhiteSpace(request.FileName))
                throw new ArgumentException("File name is required");

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            // 🔹 Insert library document
            int docOID = await _repo.InsertLibraryDocumentAsync(request);

            if (docOID <= 0)
                throw new ApplicationException("Document upload failed");

            // 🔹 Map document to litigation
            await _repo.InsertLitigationReferenceAsync(
                request.LitigationOID,
                docOID
            );

            // 🔹 Update last modified date
            await _repo.UpdateLitigationLastModifiedDate(
                request.LitigationOID
            );

            return docOID;
        }
        public async Task<int> InsertBillingAsync(BillingDetailsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.BillingOID > 0)
                throw new ArgumentException("BillingOID must be 0 for insert");

            return await _repo.InsertBillingDetailsAsync(request);
        }
        public Task<int> InsertConnectedCheque(int litigationOID, int chequeOID, int isConnected)
    => _repo.InsertConnectedCheque(litigationOID, chequeOID, isConnected);
        #endregion

        #region Update Litigation Details Page API
        public async Task<bool> UpdateLitigationLastModifiedDate( int LitigationOID)
        {
            int result = await _repo.UpdateLitigationLastModifiedDate( LitigationOID);
            return result > 0;
        }
        public async Task<int> UpdateBillingAsync(BillingDetailsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.BillingOID <= 0)
                throw new ArgumentException("BillingOID is required for update");

            return await _repo.UpdateBillingDetailsAsync(request);
        }

        public Task<int> UpdateCompletionDetails(CompletionDetailsDto model)
    => _repo.UpdateCompletionDetails(model);
        public Task<int> UpdateLitigationActionItem(ActionItemUpdateDto model)
    => _repo.UpdateLitigationActionItem(model);
        public Task<int> InsertConnectedREM(int litigationOID, int realEstateOID, int isConnected)
    => _repo.InsertConnectedREM(litigationOID, realEstateOID, isConnected);
        public Task<int> UpdateDocUploadStatusfornotices(int litigationDraftOID, int draftStatusOID)
    => _repo.UpdateDocUploadStatusfornotices(litigationDraftOID, draftStatusOID);
        public Task<int> UpdateDraftstatusNotices(int noticeDraftOID,int draftStatusOID,string assigneeComment,string reviewerComment)
    => _repo.UpdateDraftstatusNotices(noticeDraftOID,draftStatusOID, assigneeComment,reviewerComment);
        public Task<int> InsertLitigationForDrafting(List<LitigationDraftingDto> list)
    => _repo.InsertLitigationForDrafting(list);
        public Task<int> AssignMyBucketListForLitigationByDetails(int userOID,int litigationOID,int entityOID,int unitOID)
    => _repo.AssignMyBucketListForLitigationByDetails(userOID, litigationOID, entityOID, unitOID);
        #endregion

        #region Delete Litigation Details Page API's
        public Task<IEnumerable<dynamic>> DeleteInterimRecord(int MasterOID, string Type)
=> _repo.DeleteInterimRecord(MasterOID, Type);
        public Task<IEnumerable<dynamic>> DeleteConnectedNotice(int NoticeOID, int LitigationOID)
=> _repo.DeleteConnectedNotice(NoticeOID, LitigationOID);
        public Task<IEnumerable<dynamic>> DeleteConnectedLitigationFromLitigation(int Connected_LitigationOID, int LitigationOID)
=> _repo.DeleteConnectedLitigationFromLitigation(Connected_LitigationOID,LitigationOID);
        public Task<IEnumerable<dynamic>> DeleteConnectedCheque(int ChequeOID, int LitigationOID)
=> _repo.DeleteConnectedNotice(ChequeOID, LitigationOID);

        #endregion
        #endregion

        #region Litigation Summary Page API's

        public Task<IEnumerable<dynamic>> BindGridViewLitigationSummary()
=> _repo.BindGridViewLitigationSummary();

        public Task<IEnumerable<dynamic>> BindLitigationDraftSummary(int UserOID) => _repo.BindGridViewLitigationSummary();

        public Task<IEnumerable<dynamic>> DeleteLitigation(int LitigationOID)
=> _repo.DeleteLitigation(LitigationOID);

        #endregion

        /// <summary>
        /// Update Litigation Page API 
        /// </summary>
        /// <param name="LitigationOID"></param>
        /// <returns></returns>

        #region Update Litigation Page API
        public Task<IEnumerable<dynamic>> DeleteConnectedLitigation(int LitigationOID)
=> _repo.DeleteConnectedLitigation(LitigationOID);

        public async Task<bool> UpdateLitigationAsync(LitigationUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.LitigationOID <= 0)
                throw new ArgumentException("Invalid LitigationOID");

            int rowsAffected = await _repo.UpdateLitigationAsync(request);

            // Stored procedure returns number of affected rows
            return rowsAffected > 0;
        }
        public Task<IEnumerable<dynamic>> GetLitigationDocumentsPOABRLOA(int LitigationOID, string DocType)
=> _repo.GetLitigationDocumentsPOABRLOA(LitigationOID, DocType);
        #endregion

        #region Litigation Report
        public Task<IEnumerable<dynamic>> GetLitigationIDforReport(int UserOID, int UnitOID)
=> _repo.GetLitigationIDforReport( UserOID,  UnitOID);

        public Task<IEnumerable<dynamic>> GetLitigationDetailforReport(int LitigationOID,int UserOID)
=> _repo.GetLitigationDetailforReport(LitigationOID,UserOID);

        public Task<IEnumerable<dynamic>> GetLitigationActionItemSummary(int LitigationOID)
=> _repo.GetLitigationActionItemSummary(LitigationOID);
        public Task<IEnumerable<dynamic>> GetLitigationMetricsReport(LitigationMetricsFilterDto filter)
    => _repo.GetLitigationMetricsReport(filter);
        public Task<IEnumerable<dynamic>> GetMISReport(MISReportFilterDto filter)
    => _repo.GetMISReport(filter);
        public Task<IEnumerable<dynamic>> GetMISReportUnitWise(MISReportUnitWiseFilterDto filter)
    => _repo.GetMISReportUnitWise(filter);

        public Task<IEnumerable<BillTypeDto>> GetBillTypes()
    => _repo.GetBillTypes();
        public Task<IEnumerable<dynamic>> GetCompanyLawFirmByLitigationAndPartyType(int LitigationOID, int PartyTypeOID)
=> _repo.GetCompanyLawFirmByLitigationAndPartyType(LitigationOID, PartyTypeOID);
        public Task<IEnumerable<LitigationBillingReportDto>> GetLitigationBillingReport(LitigationBillingReportFilterDto filter)
    => _repo.GetLitigationBillingReport(filter);
        public Task<IEnumerable<CauseListDto>> GetCauseListReport(CauseListFilterDto filter)
    => _repo.GetCauseListReport(filter);

      //  public Task<int> InsertLitigationFromImport(SupremeCourtImportDto dto)
      //=> _repo.InsertLitigationFromImport(dto);
        #endregion

    }
}
