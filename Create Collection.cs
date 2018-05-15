// Create a Collection for ASP.NET

string api_key = "4e49de80-1670-4606-84f8-2f1d33a38670";
string title = "Put your title here";

Collection collection = new Collection();
	
//call the api to create collection id
WebRequest req = WebRequest.Create(@"https://www.billplz.com/api/v3/collections?title="+title);
req.Method = "POST";
req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(api_key));
HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    

if(resp.StatusCode == HttpStatusCode.OK)
{
	// Read the response body as string
	Stream dataStream = resp.GetResponseStream();
	StreamReader reader = new StreamReader(dataStream);
	data = reader.ReadToEnd();
	collection = JsonConvert.DeserializeObject<Collection>(data);
	// collection.Id;
	resp.Close();
}