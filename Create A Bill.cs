// Create A Bill Example for ASP.NET

string api_key = "4e49de80-1670-4606-84f8-2f1d33a38670";
string collection_id = "t0wj0l5e";
string email = "somebody@gmail.com";
string phone = "60121234567";
string name = "John Doe";
string amount = "300";
string callback_url = "http://google.com";
string description = "Any description for Bill payment";

Bill bill = new Bill();

WebRequest req = WebRequest.Create(@"https://www.billplz.com/api/v3/bills?collection_id="+collection_id+"&email="+email+"&mobile="+phone+"&name="+name+"&amount="
  +amount+ "&callback_url="+callback_url+ "&description="+description);

req.Method = "POST";
req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(api_key));

try
{
    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

    if (resp.StatusCode == HttpStatusCode.OK)
    {
        // Read the response body as string
        Stream dataStream = resp.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        data = reader.ReadToEnd();
        bill = JsonConvert.DeserializeObject<Bill>(data);
       
        resp.Close();

        //redirect user to billplz website for payment
        return Redirect(bill.Url);
    }

}
catch (Exception ex)
{
    throw new Exception(ex.Message);
}


