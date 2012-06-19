#StringSharp
*For Lazy String Formatters*

This is just a little extension that I wrote for 'convention based' string formatting.

It replaces:  
```String.Format("{0} then {1} then {2}",11,22,33);```  
with  
```"# then # then #".SharpFormat(11,22,33);```

In short, it uses ```#``` instead of ```{x}``` and (mostly) assumes increasing argument count.  Also its exposed as an extension method for ease of use.

You can **escape** to hash using ```##```  
```"C## is ###!".SharpFormat(1);```  
becomes  
```"C# is #1!"```  

You can **re-use previous arguments** by following the ```#``` with the index  
```"# first then # second then #0 first again".SharpFormat(101,202);```  
becomes  
```"101 first then 202 second then 101 first again"```  
This _only supports referencing arguments 0-9_ for simplicity.  

There are **shortcuts** for succinct method names  
```
"Hello #!".SharpFormat("Formal");  
"Hello #!".SFmt("Casual");  
"Hello #!".SF("Lazy");  
```  

Unit tests are included, **sorry ahead of time that they're in MSTest**, but I don't have anything else setup right now.  I'm open to using nUnit / xUnit, but I was going to wait for someone to care first =)
