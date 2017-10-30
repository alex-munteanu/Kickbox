# kickbox
A <a href="http://docs.kickbox.io/docs/using-the-api">Kickbox.io</a> API for .NET. This library is made using .NET Standard 1.1. It can be found on nuget <a href="https://www.nuget.org/packages/Kickbox.Net/">here</a> with the ID Kickbox.Net.

# How to use

Install package from nuget using Package Manager:
```
Install-Package Kickbox.Net
```

or .NET CLI:

```
dotnet add package Kickbox.Net
```

or Paket CLI:

```
paket add Kickbox.Net
```

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