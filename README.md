# CoreWebApplication1
Implement the Gmail snooze service.

When user click on a button to create some snooze a call to an http request (post) is being made. (CreateSnooze action in SnoozeController)
this action use other services and finally created new record on snoozedMassages table (in snoozeService.db) the represent the requested snooze.

In addition, the SnoozeScheduler app is the part for pulling the relevant messages from the db and print them to the console (instead of send email).
To schedule this part to run evry 5 minutes I use Task Scheduler as explain here: https://www.c-sharpcorner.com/article/setup-task-scheduler-to-run-application/#:~:text=Right%20click%20on%20folder%20and,executable%20file%20and%20click%20OK.
