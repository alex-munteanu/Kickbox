# kickbox
A <a href="http://docs.kickbox.io/docs/using-the-api">Kickbox.io</a> API for .NET. This library is made using .NET Standard 

# How to use

Simple validation:

```
var kickBoxApi = new KickBoxApi("KEY");
var valid = await kickBoxApi.VerifyAsync("your_email@gmail.com");
```

Validate with response:

```
var kickBoxApi = new KickBoxApi("KEY");
var valid = await kickBoxApi.VerifyWithResponse("your_email@gmail.com");
```

Where ther response will be a KickBoxResponse, with the following structure:

```
public class KickBoxResponse
{
	public string Message { get; set; }

	public int Code { get; set; }

	public string Result { get; set; }

	public string Reason { get; set; }

	public bool Role { get; set; }

	public bool Free { get; set; }

	public bool Disposable { get; set; }

	public bool AcceptAll { get; set; }

	public string DidYouMean { get; set; }

	public double Sendex { get; set; }

	public string Email { get; set; }

	public string User { get; set; }

	public string Domain { get; set; }

	public bool Success { get; set; }
}
```