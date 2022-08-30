# MedicationManagement

## Setup

This project uses MS SQL as the database to store all medication information. Please set that up if you would like to run things in the same environment as the project was developed. You can modify the connection string in appsettings.json under ConnectionStrings->DefaultConnection.

The base route for the API is /api/medication, Medication being the controller in question, in this case.

## Get All Medication

/api/medication - Simply write an HTTP GET message and you should receive a list of all the current medication available

## Create New Medication

/api/medication - Write an HTTP POST message in which the body contains a Name and a Quantity within the valid range (1 - Int32.Max). The CreationDate and Id are automatically assigned after a successful post.

## Delete Medication

/api/medication/{id} - Write an HTTP DELETE message with the respective id of the medication you would like to remove from the current list.

