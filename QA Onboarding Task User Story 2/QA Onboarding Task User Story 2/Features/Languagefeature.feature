Feature: LanguageFeature

As a Skillswap user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.

@order(1)
Scenario: Add language record with valid details
	Given User is logged into localhost URL successfull
	When Adding new '<Language>' and '<Level>' to the language list
	Then New record with '<Language>' and '<Level>' are added successfully

	Examples:
	| Language | Level                 |
	| Greek    | Fluent                |
	| Mandarin | Choose Language Level |
	|          | Choose Language Level |
	| WASD123  | Conversational        |
	| English  | Basic                 |

	@order(2)
	Scenario Outline: Update existing language record with valid details
	Given User is logged into localhost URL successfully
	When Update '<Language>' and '<Level>' on an existing language record
	Then The record should been updated '<Language>' and '<Level>' successfully

	Examples: 
	| Language | Level					|
	| Greek		| Fluent				|
	| Mandarin	| Fluent				|
	|			| Language Level		|
	| French	| Language Level		|
	| WASD123	| Native/Bilingual		|
	

	@order(3)
	Scenario Outline: Delete the language record from the language list
	Given User is logged into localhost URL successfully
	When Delete the record '<Language>' and '<Level>' from the language list
	Then The record '<Language>' and '<Level>' should be deleted successfully

	Examples: 
	| Language | Level |
	| English  | Basic |

	







