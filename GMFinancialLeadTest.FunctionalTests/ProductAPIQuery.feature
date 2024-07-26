Feature: ProductAPIQuery

A short summary of the feature
Fake Story API returns a list of products with price, descrption, category, and ratings
This feature will query all products and return a filtered list

@tag1
Scenario: FilterHighlyRatedProducts
	Given All products are requested
	When product list received
	Then filter should be applied
	And price is formated
	And results written to file
