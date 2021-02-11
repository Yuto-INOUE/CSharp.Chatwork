## CSharp.Chatwork
Chatwork API library for .NET

## How To Use
```
	var token = ChatworkToken.Create("your api key");
	token.Rooms["roomId"].Messages.PostAsync(body: "Hello, world!");
```

## Install
```
PM> Install-Package CSharp.Chatwork
```

## License
This software is licensed under the MIT License.