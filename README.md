![.NET Core](https://github.com/KelvinVail/RequestRouter/workflows/.NET%20Core/badge.svg)

# RequestRouter

RequestRouter is a set of high level policies for routing requests to multiple responders 
then aggreagting each response back to the requester.

As each requester and each responder can require differing data structures, the RequestRouter
uses a central "Standard" message structure.  

Each requester and responder is only responsible for mapping their data structure to the
standard and vise verse.

##### Installation
```
dotnet add package RequestRouter --version 1.0.0-alpha
```

## Examples
### Standards
#### Standard Request
First define a standard request structure for the request message you would like to send.
Note that each individual requester and responder should be able to map to and from this standard.

To define a standard request simply, inherit from the ```StandardRequestBase``` class and
define your data structure.

```java
public class MyStandardRequest : StandardRequestBase
{
    public string Id { get; set; }

    public string Name { get; set; }
}
```

#### Standard Response
Next define a standard response by inheriting from the ```StandardResponseBase``` class.
Like the standard request each individual should be able to map to and from this response.

```java
public class MyStandardResponse : StandardResponseBase
{
    public string Id { get; set; }

    public string RequestId { get; set; }

    public string Response { get; set; }
}
```
### Requesters
#### Request
Use the ```RequestBase``` class to define each unique request data structure.
```java
public class MyRequest : RequestBase
{
    public int RequestNumber { get; set; }

    public string MyName { get; set; }
}
```

#### Response
Use the ```ResponseBase``` class to define the response structure each requester expects
to recieve.
```java
public class MyResponse : ResponseBase
{
    public string ResponseText { get; set; }
}
```

#### RequestHandler
Create a request handler for each individual requester by inheriting from 
the ```RequestHanderBasee``` class.

Override the ```ToStandard``` method and define how request maps to the standard request.
```java
public override StandardRequestBase ToStandard(RequestBase request)
{
    var baseRequest = (MyRequest)request;

    return new MyStandardRequest
	{
		Id = baseRequest.RequestNumber.ToString(),
		Name = baseRequest.MyName,
	};
}
```
Override the ```FromStandard``` method and define how a standard response maps to a response.
```java
public override ResponseBase FromStandard(StandardResponseBase standardResponse)
{
	var standard = (MyResponse)standardResponse;

	return new MyResponse
	{
		ResponseText = standard.Response,
	};
}
```

### Responders
#### Responder
Create a responder by inheriting from the ```ResponderBase``` class.
Override the ```GetResponse``` method.
Inside the the ```GetResponse``` method add any code needed to get a response.
This could be a few lines of simple logic or more likely a call to an extrenal API.
```java
protected override StandardResponseBase GetResponse(StandardRequestBase standardRequest)
{
	var standard = (MyStandardRequest)standardRequest;

	return new MyStandardResponse
	{
		Id = "UniqueId",
		RequestId = standard.Id,
		Response = $"Hello {standard.Name}",
	};
}
```
### Summary
Bring it all together by creating a request, pass the responders you want to use
into a request handler, then ask for responses.
```java
var request = new MyRequest
{
	RequestNumber = 1,
	MyName = "Bob",
};

var responders = new List<ResponderBase>
{
	new MyResponder(),
};

var handler = new MyRequestHandler(responders);

var responses = handler.GetResponses(request);
```

Using these classes it is possible to create multilple bespoke responders able to
respond to the original request without making any changes to that request.

It is also possible to add more bespoke requesters able to communicate with all existing
responders without making any changes to those responders.  
