<div align="center">

![JishoNET](http://cdn.mutedevs.nl/nuget/JishoNET/iconSmall.png)

# JishoNET
<hr />

### API Wrapper for the Jisho API (v1)
![Nuget Downloads](https://img.shields.io/nuget/dt/JishoNET?color=56D926&label=JishoNET%20Downloads)
![GitHub Open Issues](https://img.shields.io/github/issues-raw/Myuuiii/JishoNET)
![GitHUb Latest Version](https://img.shields.io/github/v/release/Myuuiii/JishoNET?label=Latest%20Release)
</div>



This wrapper makes it easy to get definitions from Jisho.
Jisho is a powerful Japanese-English dictionary and lets you find words, kanji and example sentences quickly and easily [Jisho Website](https://jisho.org/) 

<br>

# Downloads
**Stable builds can be found here**:
[NuGet](https://www.nuget.org/packages/JishoNET/)

<br>

# Usage
To get a definition from the Jisho API here's what you should do:

## Create an instance of the JishoClient
```cs
JishoClient client = new JishoClient();
```
Using this client you can start retrieving definitions.

## Retrieving a definition
On the instance of `JishoClient` you just created you can execute the `GetDefinition` method. As the argument for this method you provide the "keyword" to use in the search. This can be any English or Japanese word. The `GetDefinition` returns a `JishoResult` which will contain all the data sent back by the API.
```cs
JishoResult result = client.GetDefinition("house");
```

## Retrieving a quick definition
A quick definition contains the top result from a query, the result will contain an English `Sense` object and a `Japanese` reading object.
```cs
QuickDefinition qDefinition = client.GetQuickDefinition("house");
```


## Reading the data
The root object of type `JishoResult` contains a `Meta` and `Data` property alongside the `Success` and `Exception` property which will return the exception if anything goes wrong during the creation and execution of the API call. This is purely for development purposes and if you manage to throw an exception let me know.

## Retrieving a quick definition
A quick definition contains the top result from a query, the result will contain an English `Sense` object and a `Japanese` reading object.
```cs
QuickDefinition qDefinition = client.GetQuickDefinition("house");
```

<br>

The `Meta` object contains one property called `Status`. This property contains the Http Response Code (e.g. 200 or 404)

<br>

The `Data` list of objects contains all the definitions that were returned using your search query. Every `JishoData` object contains:


| Property    |                                                                                                                                                                                                                  |
| ----------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Slug        | The slug is the set of Kanji or Kana characters of the word you requested                                                                                                                                        |
| IsCommon    | Indicates if the requested word is common in the Japanese Language                                                                                                                                               |
| Tags        | Ay tags that have been added to the definition                                                                                                                                                                   |
| Jlpt*       | Indicates in which level of the Japanese Language Proficiency Test this word will start appearing                                                                                                                |
| Japanese    | All the Japanese reading for the word, this property contains a list of objects where `Word` is most often the reading in kanji and `Reading` is the reading written in kana characters.                         |
| Senses      | All the English definitions of the word. This property contains an object with: All English Definitions, Parts of speech (e.g. "Noun"), Links, Tags, Restrictions, SeeAlso, Antonyms, Source, Info and Sentences |
| Attribution | Contains attribution data                                                                                                                                                                                        |

\* can be empty
<br><br>

# Future Updates
- [ ] Quickly retrieve the top result from a query with "GetQuickDefinition(string request)"

# Information
If anything's not working feel free to create an issue and I'll take a look at it! I'll try to keep this wrapper working if the API updates. 
