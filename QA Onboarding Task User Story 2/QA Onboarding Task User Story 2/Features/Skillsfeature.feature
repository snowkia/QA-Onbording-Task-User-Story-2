Feature: Skillsfeature

As a Skillswap user I would be able to show what skills I know.
So that the people seeking for skills can look at what details I hold.

@order(1)
Scenario:Add Skill recored with valid details
	Given User is logged into Skillswap website successfully.
	When Adding new '<Skill>' and '<SkillLevel>' to the skill list 
	Then New skill record with '<Skill>' and '<SkillLevel>' are added successfully. 

	Examples: 
	| Skill  | SkillLevel         |
	|        | Expert             |
	|        | Choose Skill Level |
	| %$#^&* | Intermediate       |
	| C#     | Choose Skill Level |
	|        | Beginner           |

	@order(2)
	Scenario Outline: Update existing Skill records with valid details
	Given User is logged into Skillswap website successfully.
	When Update '<Skill>' and '<SkillLevel>' on an existing skill record.
	Then The skill record should been updated '<Skill>' and '<SkillLevel>' Successfully

	Examples: 
	| Skill      | SkillLevel  |
	| Java       | Expert      |
	|            | Skill Level |
	| C#         | Skill Level |
	| Salesforce | Beginner    |
	| 5$#@67 (   | Expert      |


	@order(3)
	Scenario Outline: Delete the Skill from the skill lists
	Given User is logged into Skillswap website successfully.
	When Delete the record '<Skill>' and '<SkillLevel>' successfully
	Then The record '<Skill>' and '<SkillLevel>' should deleted successfully

	Examples:
	| Skill      | SkillLevel		|
	| Salesforce | Beginner		    |








