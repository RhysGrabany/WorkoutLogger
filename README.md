# Workout Logger
WORK IN PROGRESS
### Abstract
This is a program that allows users to log their Workout progress in a clear and decriptive way.<br> The aim of this program is to minimise the amount of time the user has to log in their exercises and weights for each set, and spend more time in actually working out.

---
## Contents Page
* [Features](#features)
* [Component Breakdown](#componentbreakdown)
  * [Main Form](#mainform)
  * [Load Form](#loadform)
* [Footnote](#footnote)

---
<a name="features"></a>
#### Features include:

  1. Allowing the logging of up to 10 exercises
  2. Allowing the logging of the users daily weight
  3. Up to 5 sets per exercise
  4. Saving a template for quick and easy logging
  5. Ability to look at older dates to see how the user performed that day
  6. Able to save data in either XML or Json

---
<a name="componentbreakdown"></a>
<a name="mainform"></a>
## Main Form (WorkoutLogger)

<img align="centre" width="763" height="741" src="https://github.com/RhysGrabany/WorkoutLogger/blob/master/readme_imgs/main.PNG">

This is the main form for this application. This has most of the features included that have been outlined above. Design implementations outlined below:

* Component 1: This is the Day Functionality for the form. Functions for this grouping:
  * Component 1a: Day Name: This is the name the user will give for the day. This helps with differentiaing between workouts on the same day, but can have different names.
  * Component 1b: Save Day: This button takes in all the required data from the form (Day Name, Exercises with Weights and Reps, and Weight) and saves to a location on file. Objects can be saved as XML or JSON.
  * Component 1c: Load Day: This opens a separate form called Load Day. This form will be explained more further down, but this gives you the ability to load previously saved days and view how you performed. You will not be able to edit these days however.
  * Component 1d: Daily Weight: You can put your weight into this textbox to be saved for the future. This is not a required field however and can be skipped, loading past days will show 0 for this  area if no value is given.
* Component 2: This is the Template Functionality. This allows you to load previously saved templates to speed up form input. Functions for this grouping:
  * Component 2a: Template Name: The name you can give for this individual template. This will be the main identifier for the future so this is required. Saving a template with the same name as an older template will overwrite it with the newest.
  * Component 2b: Save Template: Once all required fields are filled (Template Name, and exercises with a weight for a set) then the template will be saved for the future. If you have fully filled out the form, and only then want to save the form contents for a template, this can be done due to the template saving only focuses on the Exercises and Weight textboxes.
  * Component 2c: Load Template Dropdown: This is a dropdown box that will have a list of all templates that have been saved. Selecting one and then clicking the load button will fill in the required textboxes. 
  * Component 2d: Load Template: After selecting a template, the load button can then be clicked and will fill in the textboxes relating to this template. This will also fill the Day Name with the Template Name to speed up form completion.
  * Component 2e: Delete Template: After selecting a template, you could also delete it and the program will remove the template from file and dropdown option.
* Component 3: Clear All Textboxes: This button will clear all the textboxes on the form. This is particularly useful after Loading a day and you aren't able to save it to clear the form that way. Clearing the boxes is faster.
* Component 4: Exercise Boxes: This is where you can input the name of the exercise being completed. If you are completing more than five sets for a single exercise, you can skip filling in more than one exercise as long as the sets are filled in. For example, Deadlift for eight sets, you can input the exercise name (Deadlift) in the first box, do five sets, and skip filling in the next exercise box and continue with filling in the weights and reps, then continue with the next exercise on the next line.
* Component 5: Weight Boxes: This is where you input the weight for that set. These textboxes appear for each set as per the groupbox name.
* Component 6: Rep Boxes: This is where you input the reps for that set. These textboxes appear for each set as per the groupbox name.
* Component 7: Notes Box: This is where you can input any additional information on your workout that you may need to remember. For example, if you had an injury, or it's the first time you completed a certain exercise.
* Component 8: Exit Button: Click this if you want to exit the application.

<a name="loadform"></a>
## Load Day Form

<img align="right" width="312" height="558" src="https://github.com/RhysGrabany/WorkoutLogger/blob/master/readme_imgs/load.PNG">


This is the form with the main ability of loading previously completed, and saved, days so you can view your self-progress. <br>
The functionality for each component is outlined below:<br>

* Component 1: Name Heading: This is the name given for that specific day. This is useful if you want to load a day to check to see how you performed before going about your day.
* Component 2: Date Heading: This is the date for the specific day. This is self-explanatory.
* Component 3: Load Day: This button allows you to load a selected date from the list. After clicking this button, the current window will close and the main form will be filled with the information. All these textboxes will then be set to readonly, and so will the Save Day button. This is to stop overwritting and keeps complexity to a low.
* Component 4: Delete Day: After selecting a date from the list view, you can also choose to delete the information. This will remove the option from the list view and delete the data on disk.
* Component 5: Exit Button: Clicking this will close the current window and return to the main form. 







<a name="footnote"></a>
<details>
  <summary>My footnote</summary>
This is my first application created in C#, as such there may be design implmentations that could be questionable.

Thank you for your understanding, this will be more filled out as development continues
</details>
