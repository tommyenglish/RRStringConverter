/*
RR Code Challenge
Convert the following string: 

`"(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)"`

To this output: 

```
- id
- name
- email
- type
  - id
  - name
  - customFields
    - c1
    - c2
    - c3
- externalId
```

And also to this output:

```
- email
- externalId
- id
- name
- type
  - customFields
    - c1
    - c2
    - c3
  - id
  - name
```
*/


using RRStringConverter.Processors;

string itemToProcess = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";

ICodeChallengeProcessor processor = new FrontToBackProcessor();
string result = processor.ConvertString(itemToProcess);
Console.WriteLine(processor.Name);
Console.WriteLine(result);

processor = new TreeNodeProcessor();
result = processor.ConvertString(itemToProcess);
Console.WriteLine(processor.Name);
Console.WriteLine(result);
