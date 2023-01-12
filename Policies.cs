using Microsoft.AspNetCore.Authorization;

namespace WebAssemblyF
{
	public class Policies {
		
		public const string IsAdmin = "IsSysAdmin";
		public const string IsCompetitionAdmin = "IsCompetitionAdmin";
		public const string IsParticipant = "IsParticipant";

			public static AuthorizationPolicy IsAdminPolicy()
			{
				return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
													   .RequireRole("System administrator")
													   .Build();
			}

			public static AuthorizationPolicy IsCompetitionAdminPolicy()
			{
				return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
													   .RequireRole("Competition administrator")
													   .Build();
			}
		public static AuthorizationPolicy IsParticipantPolicy()
		{
			return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
												   .RequireRole("Participant")
												   .Build();
		}
	}
}
