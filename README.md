# Books At Your Doorstep

Books At Your Doorstep is a full-stack web application that allows users to lend or borrow books. Lenders can upload book details to the digital library, and borrowers can borrow books from the digital library. Upon borrowing or returning, confirmation emails are sent to both users.

## Features

- There are two types of users to this system - lenders and borrowers. Created a login/sign-up system to let the users register themselves to access the portal.
- The Lender's dashboard contains 'Add Books' view, where he can add the details of books he wants to upload, 'My Books' view displays his added books or wants to update/delete the book details, 'My Book Orders' - where he can see the status of his uploaded books such as the borrowers of his books.
- Borrower's dashboard contains a 'Books Gallery' view where he can browse through all the books added by different lenders on the portal. Each book has a book details view. He can select different books and add them to his orders. The 'Orders' view enables the user to borrow or return or check the status of his books, such as the due date of the borrowed books.
- Each time a user borrows/returns a book, both the borrower and the lender are sent a confirmation mail.

## Deployment

The app has been deployed on Microsoft Azure and can be accessed using the following link:

http://bayds.azurewebsites.net/

## Technologies Used

- ASP.NET MVC 5 framework
- Microsoft Visual Studio 2019
- C#
- cshtml for views
- MS SQL Server on Azure

## Future Improvements

- Allow users to rate and review books.
- Implement a recommendation system based on user preferences and ratings.
- Add more advanced search and filter options for books.
- Integrate payment gateways for late returns and lost books.
