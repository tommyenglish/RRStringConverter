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
Console.WriteLine("Let's go!");
