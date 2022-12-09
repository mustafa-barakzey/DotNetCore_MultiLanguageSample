# DotNetCore_MultiLanguageSample

In this example, you can see the complete multilingual implementation of the site, 
which is implemented with .NET Core 6 and EF Core 6 technology, and you can use it for all database tables.
To implement, we have two database tables, one of which is called 
# TranslationLanguageModel 
 has two columns, one of which is for the language, which is defined as an enum,
 which can be linked to a database table and implemented, and the other column contains content that is The selected language is written and saved.
 The second database table of 
# TranslationModel 
contains a list of TranslationLanguageModel, which has the role of keeping the content, 
where a record is stored for each content, and that list is the same content translations in different languages.
In the table shown in the example, we have a product table that includes the title, short description, and long description, 
for each of these columns, a record is stored in the table above, and its ID is placed in the product table for the corresponding column, 
and you can use EF core relations easily retrieve the content of one language or several languages.

For the ease of working with multilingual information, a series of extension methods have been written, 
which makes retrieving and storing work to an acceptable extent, and it is also good in terms of performance, additional information is not retrieved and....

//

You can also inform about the advantages and disadvantages of this method.

Some of these extension methods are not complete and maybe with your help I can complete them.

thanks
