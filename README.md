`Disclaimer:` I try to be discreet as much as possible about company but I might fail it at some point. ==Repository shall remain!==.

`SECOND IMPORTANT NOTE:` I use [Typora](https://typora.io/) for md file editing and I have a very customized setup for various MD format properties, like highlight, bold, italic text etc. if the text looks weird it is because of my custom CSS setup.

# Code Test #2583

## Requirements

code test is to test knowledge about .net core and some basic functionality. solution is already provided but with missing parts. there are three assignments to do and it is supposed to be done in sequentially.
there are tests provided and the tests are all red because implementation is needed/missing, which is the focus of the assignments.

assignments should be done with a few hours, not longer.

## Design

the application is like a finance application which has some services about Account, ExchangeRate, Currency and Transaction list. the services provide them (via interface) and implementations are missing (for assignment). https://localhost:5001/account?currency=EUR is the only API that works from outside

### Assignment 1

make ConversionServiceTests pass, which means implement ConversionService. running the application is not necessary in this assignment

### Assignment 2

run the application, which means several services are needed to be implemented. the API mentioned above has to be working with some values.
one service is excluded from the implementations, TransactionService. its implementation is in third assignment
another part of the assignment is to use files from outside, which are provided in the description of the code test. basically a special server has to be called and **/account.json** and **/currencies.json** has to be used instead of hardcoded values.

### Assignment 3

TransactionService has one function which is to calculate highest positive balance change. it is going to check the balance values and find within which dates the account balance has increased continuously (no decrease) and it should list the dates and also total increase. the balance might have different date ranges for increase but the function should find the highest increase within given transaction list.

# Environment & Compilation

Application is provided with NetCore 3.1. runs a basic AspNetCore service with a few APIs present.

# Final Changes

although unnecessary, to make above public the out server to get account and currency json files is put to settings of the app.
no additional tasks are done and no change was necessary.