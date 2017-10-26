# Mendz.ETL
Provides APIs for developing extract, transform and load (ETL) solutions. [Wiki](https://github.com/etmendz/Mendz.ETL/wiki)
## Namespace
Mendz.ETL
### Contents
Name | Description
---- | -----------
Router | The ETL router that provides methods to execute the ETL.
DocumentSpecification | Represents a document specification and details.
SourceAdapterBase | The base source adapter.
MapperBase | The base mapper.
TargetAdapterBase | The base target adapter.
ValidatorBase | The base validator.
JoinerBase | The base joiner.
ISourceAdapter | Defines a source that extracts input.
IMapper | Defines a mapper that transforms inputs to outputs.
ITargetAdapter | Defines a target that loads output.
IValidator | Defines a validator.
IJoiner | Defines a joiner.
ITargetable | Defines a targetable source.
ISourceable | Defines a sourceable target.
ETLSourceAdapterException | Represents a source adapter exception.
ETLMapperException | Represents a mapper exception.
ETLTargetAdapterException | Represents a target adapter exception.
ETLValidatorException | Represents a validator exception.
ETLSourceAdapterEventHandler | Represents a source adapter event handler.
ETLSourceAdapterEventArgs | Represents a source adapter event argument.
ETLMapperEventHandler | Represents a mapper event handler.
ETLMapperEventArgs | Represents a mapper event argument.
ETLTargetAdapterEventHandler | Represents a target adapter event handler.
ETLTargetAdapterEventArgs | Represents a target adapter event argument.
ETLValidatorEventHandler | Represents a validator event handler.
ETLValidatorEventArgs | Represents a validator event argument.
## The Ingredients
With Mendz.ETL, an ETL solution has three (3) main ingredients:
1. **Source adapter**, which extracts the inputs from the source. Can derive from SourceAdapterBase and implement abstract method ExtractInput(). Call via Extract() method.
2. **Mapper**, which transforms the inputs to outputs. Can derive from MapperBase and implement abstract method TransformInputToOutput(). Call via Transform() method.
3. **Target adapter**, which loads outputs to the target. Can derive from TargetAdapterBase and implement abstract method LoadOutput(). Call via Load() method.

Mendz.ETL adds two optional ingredients:
1. **Validator**, which can be used to validate the source (before extracting) or the target (after loading). Can derive from ValidatorBase and implement abstract method ValidateDocument(). Call via Validate() method.
2. **Joiner**, which can be used to extract, query and join multiple sources in to mappable inputs. Can derive from JoinerBase and implement abstract method Join(). Call via same implemented Join() method.
## The Router
When the ingredients are ready, they can be put together and routed to execute the ETL operation.
**Mendz.ETL.Router** is a static class that provides the following static methods:
- Route(), which routes the source via mapper to target.
- ChainRoute(), which routes the source via mapper to target, then chains the result to another mapper/target pair, and then to another mapper/target pair, etc. until all mapper/target pairs are consumed.
- MergeRoute(), which routes multiple source/mapper pairs to target.
- SplitRoute(), which routes a source to multiple mapper/target pairs.
- JoinRoute(), which joins multiple sources and routes the result via mapper to target.
- JoinSplitRoute(), which joins multiple sources and routes the result to multiple mapper/target pairs.

The Router is provided as an initial convenience. The ingredients you create using Mendz.ETL can be easily put together and executed through the existing Router methods. However, you can also create your own "router" methods to satisfy new and unique requirements in your ETL solutions.
## What is Mendz.ETL for?
Mendz.ETL is a foundational library of APIs that can be used to create custom/proprietary ETL products and their SDKs.

Mendz.ETL provides the tools and guidance for building the different ingredients of an ETL solution.
These ingredients are designed to work together to complete an extract, transform and load data flow.
The ingredients can be created to explicitly solve a simple ETL requirement. Or,
they can also be created "generic" and configuration driven to solve for various complex ETL requirements.

The source adapters, mappers, target adapters and validators also support event driven development.
This feature provides greater flexibility in defining custom behaviors and processes during an ETL operation.

Mendz.ETL, therefore, is not the product. The ETL solution you create using Mendz.ETL is the product.
Mendz.ETL simply provides the architectural structure or foundation to let you create ETL solutions
that support streaming reads, streaming mappings and streaming writes by design;
with options to validate, join, merge, split and chain data flows; and
the capability to customize or extend behaviors via events.
## Imagine the possibilities!
ETL solutions enable application integrations by supporting data transformations from one format to another. Mendz.ETL is designed to let you create ETL solutions that support any-to-any transformations.

You can, for example, create direct, one-off ETL solutions:
- ACMEOrderSourceAdapter via ACMEOrderToMyOrderMapper to MyOrderTargetAdapter
- PartnerInvoiceSourceAdapter via PartnerInvoiceToAcknowledgementReceiptMapper to AcknowledgementReceiptTargetAdapter
- JournalSourceAdapter via JournalToBalanceSheetMapper to BalanceSheetTargetAdapter,
via BalanceSheetToFinancialStatementMapper to FinancialStatementTargetAdapter.

Or, you can, for example, create configurable/re-useable components for your ETL solutions:
- XmlSourceAdapter via XsltMapper to XmlTargetAdapter
- FlatFileSourceAdapter via FlatFileMapper to FlatFileTargetAdapter
- XmlSourceAdapter via XsltMapper to FlatFileTargetAdapter.
- FlatFileSourceAdapter via FlatFileToXmlMapper to XmlTargetAdapter.
- MongoCustomerSourceAdapter via JSONToXmlMapper to CustomerWSTargetAdapter.
- CustomerWSSourceAdapter via XmlToJSONMapper to MongoCustomerTargetAdapter.

Sample use/execution:
```C#
...
// initialize document specifications and validators...
ISourceAdapter source = new XmlSourceAdapter();
// source.SourceSpecification = sourceSpecification;
// source.Validator = sourceXmlValidator;
IMapper mapper = new XsltMapper();
// set mapper properties...
ITargetAdapter target = new FlatFileTargetAdapter();
// target.TargetSpecification = targetSpecification;
// target.Validator = targetXmlValidator;
Router.Route(source, mapper, target);
...
```
## NuGet It...
[https://www.nuget.org/packages/Mendz.ETL/](https://www.nuget.org/packages/Mendz.ETL/)
