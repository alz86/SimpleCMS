
# Simple CMS Plugin Integration Guide

## Overview
This plugin enhances an ABP.io based system with CMS capabilities. It allows for the creation of new pages with enriched (HTML) content, integrating them seamlessly into the system's main navigation menu. Each new page is referred to as an “Entry,” and it's made up of the following fields:

- **Name**: An internal identifier for easy reference.
- **Title**: The title of the entry. It appears as the page name in the navigation bar and as the main title on the page.
- **Content**: The body of the entry, capable of containing HTML.

## Setup Instructions

### Compiling the Project
First, you need to compile the project. This is facilitated by an included script, `build.sh`. When executed, this script compiles the solution and copies the plugin files into a `dist` folder at the project root.

### Plugin Integration Process
1. **Create a New Folder**: Begin by creating a new folder.
2. **Generate New Application**: Inside this folder, run the command `abp new TodoApp` to create a new test application.
3. **Copy Plugin DLLs**: Next, copy the plugin's DLLs into a directory that the new application can access, for example, `src/libs/Plugins`.
4. **Load DLLs into the Web Application**: 
    - Go to `TodoApp.Web\Startup.cs`.
    - At the line with the method call `builder.AddApplicationAsync<xx>`, you need to add a callback to incorporate the new plugins folder. For example:
    ```
    await builder.AddApplicationAsync<TodoAppWebModule>(options =>
        {
            var currentDirectory = options.Services.GetHostingEnvironment().ContentRootPath;
            var plugDllInPath = currentDirectory + @"\..\libs\plugins";
            options.PlugInSources.AddFolder(plugDllInPath);
        });
	```
	Remember to also add a using like `using Volo.Abp.Modularity.PlugIns;`.

### Database Integration (For Entity Framework Projects)

In the event that the project works with Entity Framework (as in this example), the necessary migrations must be created to create the tables in the database. Here are the steps:
			
1. **Open Your Solution**: Begin by opening your solution.
2. **Reference the Plugin Library**: In the `.EntityFrameworkCore` project, add a reference to `DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore.dll`.
3. **Update DbContext**: In your DbContext file (like `TodoAppDbContext.cs`), add the namespace `using DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;` and then in the `OnModelCreating` method, include the line `builder.ConfigureSimpleCMS();`.
4. **Create and Run Migrations**: Create a new migration using your preferred method. For example, navigate to your `.EntityFramework` project directory and run `dotnet ef migrations add SimpleCMS-Added`, then apply the migration with `dotnet ef database update`.

### Post-Installation Configuration

The plugin is already installed and ready to be used. But it should be noted that, initially, the only access point to the plugin's functionalities is through the "Manage Entries" menu item, which is only displayed if the user has the "Create/Edit Entries" permission. Therefore, the first action to take is to assign this permission to the administrator user.
	
1. Start by logging in with an administrator account.
2. Navigate to the Administration menu, select Manage Identities, then Users.
3. Find and select the current user, then in the “Options” dropdown, choose Permissions.
4. In the dialog that appears, look for the SimpleCMS section and assign the “Create/Edit Entries” permission to the user.
5. Save your changes and refresh the page. The “Manage Entries” menu option should now be available.

## Additional Notes
- This module relies on `Volo.Abp.VirtualFileSystem`. This module is included by default in the startup templates of ABP applications.

## Supported Languages

Currently, the plugin is translated into the following languages:

- English
- Spanish
