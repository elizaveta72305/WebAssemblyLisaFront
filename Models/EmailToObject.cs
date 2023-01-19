namespace WebAssemblyF.Models
{
	public class EmailToObject
	{
		public string email { get; set; }
		public List<string> listOfParticipantsEmail { get; set; }

		public EmailToObject(string email, List<string> listOfParticipantsEmail)
		{
			this.email = email;
			this.listOfParticipantsEmail = listOfParticipantsEmail;
		}
	}
}
