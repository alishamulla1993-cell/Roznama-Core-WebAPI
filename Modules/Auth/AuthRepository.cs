using Dapper;
using Roznama.Common.Helpers;
using Roznama.Infrastructure.Database;
using Roznama.Models.Auth;
using System.Data;

namespace Roznama.Modules.Auth
{
    public class AuthRepository : RepositoryBase
    {
        private readonly TokenHelper _token;

        public AuthRepository(
            DbConnectionFactory dbFactory,
            DapperHelper dapper,
            TokenHelper token) : base(dbFactory, dapper)
        {
            _token = token;
        }

        public async Task<LoginResponse?> AuthenticateAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return null;

                using var conn = CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@vLoginID", username);

                var user = await conn.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_GetUserPwd",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (user == null)
                    return null;

                string encryptedInputPwd;
                try
                {
                    encryptedInputPwd = EncryptionHelper.Encrypt(password);
                }
                catch (Exception ex)
                {
                    throw new Exception("Password encryption failed", ex);
                }

                if (encryptedInputPwd != user.LOGIN_PASSWORD)
                    return null;

                string token;
                try
                {
                    token = _token.GenerateToken(
                        user.LOGIN_ID.ToString(),
                        user.OID.ToString(),
                        user.RoleDesc.ToString()
                    );
                }
                catch (Exception ex)
                {
                    throw new Exception("Token generation failed", ex);
                }

                return new LoginResponse
                {
                    UserOID = user.OID,
                    LoginID = user.LOGIN_ID,
                    FullName = $"{user.FIRST_NAME} {user.LAST_NAME}",
                    Role = user.RoleDesc,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                // 🔥 THIS PREVENTS ERR_EMPTY_RESPONSE
                throw new Exception("AuthenticateAsync crashed", ex);
            }
        }
    }
}