What's Toxy
============

Toxy is a .NET data/text extraction framework similar to Apache Tika in Java. It supports a lot of popular formats such as docx, xlsx, xls, pdf, csv, txt, epub, html and so on.



Why Toxy
============

In the past, we have to use IFilter to extract texts from other documents. But Toxy is platform independent. It will try to support not only Windows but also Linux (with Mono installed). The usage of Toxy will be very easy. You don't need to care much about what extension you are extracting because it will create a clever framework to help identify the file formats and extract the data/text into a unified structure. 

For documents, there will be a structure called ToxyDocument.
For spreadsheets, there will be a structure called ToxySpreadsheet.
