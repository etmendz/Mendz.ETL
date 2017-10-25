# Mendz.ETL
Provides APIs for developing extract, transform and load (ETL) solutions.
## Namespace
Mendz.ETL
### Contents
## The Ingredients
With Mendz.ETL, an ETL solution has three (3) main ingredients:
1. Source adapter, which extracts the inputs from the source.
2. Mapper, which transforms the inputs to outputs.
3. Target adapter, which loads outputs to the target.

Mendz.ETL adds two optional ingredients:
1. Validator, which can be used to validate the source (before extracting) or the target (after loading).
2. Joiner, which can be used to extract, query and join multiple sources in to mappable inputs.
## The Router
When the ingredients are ready, they can be routed to execute the ETL operation.
Mendz.ETL has the Router, which provides the following methods:
- Route(), which routes the source via mapper to target.
- ChainRoute(), which routes the source via mapper to target, and chains the result to another mapper/target pair, and so on.
- MergeRoute(), which routes multiple source/mapper pairs to target.
- SplitRoute(), which routes a source to multiple mapper/target pairs.
- JoinRoute(), which joins multiple sources and routes the result via mapper to target.
- JoinSplitRoute(), which joins multiple sources and routes the result to multiple mapper/target pairs.
## What is Mendz.ETL For?
Mendz.ETL is a foundational library of APIs that can be used to create custom/proprietary ETL products and their SDKs.

Mendz.ETL provides the tools and guidance to building the different ingredients of an ETL solution.
These ingredients are designed to work together to complete an extract, transform and load data flow.
The ingredients can be created to explicitly solve a simple ETL requirement. Or,
they can also be created "generic" and configuration driven to solve for various complex ETL requirements.

Mendz.ETL, therefore, is not the product. The ETL solution you create using Mendz.ETL is the product.
Mendz.ETL simply provides the architectural structure or foundation to let you create ETL solutions
that support streaming reads, streaming mappings and streaming writes by design,
with options to validate, join, merge, split and chain data flows. 
## NuGet It...
[https://www.nuget.org/packages/Mendz.ETL/](https://www.nuget.org/packages/Mendz.ETL/)
