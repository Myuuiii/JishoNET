# JishoNET Documentation

## Getting started

To get started with JishoNET please follow the steps below!

### Setting up a JishoClient

```cs
JishoClient client = new JishoClient();
```

## Retrieving a set of definitions 

### Synchronous

```cs
JishoResult<JishoDefinition> result = client.GetDefinition("川口");
```

### Asynchronous

```cs
JishoResult<JishoDefinition> result = await client.GetDefinitionAsync("川口");
```

## Retrieving a single definition

### Synchronous

```cs
JishoQuickDefinition qDef = client.GetQuickDefinition("川口");
```

### Asynchronous

```cs
JishoQuickDefinition qDef = await client.GetQuickDefinitionAsync("川口");
```

## Reading definition data

### JishoDefinition

| Property    |                                                                                                                                                                                                                  |
| ----------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Slug        | The slug is the set of Kanji or Kana characters of the word you requested                                                                                                                                        |
| IsCommon    | Indicates if the requested word is common in the Japanese Language                                                                                                                                               |
| Tags        | Ay tags that have been added to the definition                                                                                                                                                                   |
| Jlpt*       | Indicates in which level of the Japanese Language Proficiency Test this word will start appearing                                                                                                                |
| Japanese    | All the Japanese reading for the word, this property contains a list of objects where `Word` is most often the reading in kanji and `Reading` is the reading written in kana characters.                         |
| Senses      | All the English definitions of the word. This property contains an object with: All English Definitions, Parts of speech (e.g. "Noun"), Links, Tags, Restrictions, SeeAlso, Antonyms, Source, Info and Sentences |
| Attribution | Contains attribution data                                                                                                                                                                                        |