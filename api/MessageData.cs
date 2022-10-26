using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace api
{
	public static class MessageData
	{
		private static IEnumerable<MessageModel> Messages = new List<MessageModel>()
		{
			new MessageModel(1, "Hello Network 10"),
			new MessageModel(2, "Hello Network 11"),
			new MessageModel(3, "Hello Network 12"),
			new MessageModel(4, "Hello Network 13"),
		};

		public static IEnumerable<MessageModel> GetMessages() => Messages;

		public static IEnumerable<MessageModel> AddMessage(MessageModel messageModel)
		{
			Messages = Messages.Append(messageModel);
			return Messages;
		}

		public static MessageModel EditMessage(int id, string message)
		{
			var messageModel = Messages.FirstOrDefault(x => x.Id == id);
			messageModel.Message = message;
			return messageModel;
		}

		public static void DeleteMessage(int id)
		{
			Messages = Messages.Where(x => x.Id != id);
		}
	}

	public class MessageModel
	{
		public int Id { get; set; }
		public string Message { get; set; }

		public MessageModel()
		{

		}

		public MessageModel(int id, string message)
		{
			Id = id;
			Message = message;
		}
	}
}
