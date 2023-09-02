# BankingApplication

## Important

This solo project was developed independently during two interrelated university courses. The original project was properly version-controlled with Git, but it was developed in a private repository because it contains private information about my studies and my Software Development course. This repository contains only the finished application.

## Description

This application is meant to help interact with an underlying database by basic Create/Read/Update/Delete methods. Other than that, there are also some non-CRUD methods, that provide basic aggregated data about the database. All of these methods can be reached by connecting to the application's endpoint (ASP .Net Core). 

This is an end-to-end project both with finished backend and frontend components. SignalR is implemented on the endpoint, so users see the real-time state of the database, even if multiple users are working on it.

### Frontend

There are three independent clients implemented as a basic frontend:

* 'BankApplication.Client': A basic console application with a simple menu system.
* 'BankApplication.JSClient': A basic web application created with the help of plain JavaScript, HTML and CSS. 
* 'BankApplication.WPFClient': A WPF application that provides a basic interactive UI for the user. To distinguish the business logic from the UI, I created this application by using the MVVM design pattern.

### Backend

* 'BankApplication.Repository': This layer is responsible for initializing and setting up the underlying database. It contains a generic 'Repository' class that contains all the possible CRUD implementations and all the different model repositories will be the child of this class. It provides an 'IRepository' interface so the following Logic layer can communicate with it through this interface. At the moment it uses an In Memory Database but it can be easily changed to a real database.
  
* 'BankApplication.Logic': This layer defines all the business logic of the different models, including the data validation and aggregation. Exceptions caused by wrong input are raised in this layer. Provides an I<model>Logic for each model type, so the Endpoint can communicate with this layer through these interfaces.
  
* 'BankApplication.Endpoint': Provides an API for the backend so the clients can communicate with the database. 

* 'BankApplication.Test': Contains multiple unit tests with a Mock database to test the most important functionalities of the application.

### Shared

* 'BankApplication.Models': Contains the pre-defined templates for each model used in the application (BankCard, CurrentAccount and Customer). Also contains some DTOs (Data Transfer Object), that are used during the aggregating non-CRUD methods.
