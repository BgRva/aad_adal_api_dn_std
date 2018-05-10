AADx APIs (.net Standard)
=========================
This project is part of the Azure AD authentication model and provides two APIs, each
in a separate project.  Each API is constucted using asp.net Standard 4.61

## Step C
Roles Integration with AAD

This version implements roles in a hierarchy, so that users only need one role per API
or _GlobalAdmin_ which is access to all behavior

Role Hierarchy:

 - GlobalAdmin
   - ToDoAdmin
     - ToDoApprover
       - ToDoWriter
         - ToDoObserver
   - EventAdmin
     - EventApprover
       - EventWriter
         - EventObserver

## Changes from Step_B
Start with branch Step_B and make the following changes

1) This version uses different app registrations 'Step_C_*'

2) Roles specified in each api application registration manifest

Roles for **Todo Api**

    "appRoles": [{
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "ToDo Observer",
		    "id": "B240D714-1C17-4609-B88B-59C3843D5B0C",
		    "isEnabled": true,
		    "description": "Observers only have the ability to view todo itesm.",
		    "value": "ToDoObserver"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "ToDo Writer",
		    "id": "7DA7EB2E-6842-47F1-91BA-48D9959F5B2C",
		    "isEnabled": true,
		    "description": "Writers Have the ability to create todo items.",
		    "value": "ToDoWriter"
	    },{
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "ToDo Approver",
		    "id": "1C860A0F-1A05-4535-BD70-4D5267BCB37B",
		    "isEnabled": true,
		    "description": "Approvers have the ability to change todo items.",
		    "value": "ToDoApprover"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "ToDo Admin",
		    "id": "75BFDC80-3C91-4B29-A6AC-D0129843E9FB",
		    "isEnabled": true,
		    "description": "Admins can manage roles and perform all todo actions.",
		    "value": "ToDoAdmin"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Global Admin",
		    "id": "212C70F6-EF65-4004-B223-A72694F77812",
		    "isEnabled": true,
		    "description": "Full control",
		    "value": "GlobalAdmin"
	    }
    ],


Roles for **Events Api**

    "appRoles": [{
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Event Observer",
		    "id": "FA8C8E52-0462-4F4C-89BB-2246AEDF7106",
		    "isEnabled": true,
		    "description": "Observers only have the ability to view event itesm.",
		    "value": "EventObserver"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Event Writer",
		    "id": "18034FEB-D60C-44B2-9376-EDB93C98A868",
		    "isEnabled": true,
		    "description": "Writers Have the ability to create event items.",
		    "value": "EventWriter"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Event Approver",
		    "id": "393BDA03-6C17-4078-84AF-E31EF0F5BB40",
		    "isEnabled": true,
		    "description": "Approvers have the ability to change event items.",
		    "value": "EventApprover"
	    }, {
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Event Admin",
		    "id": "8CB6A27C-1C02-4824-B9AD-F606DB660F6E",
		    "isEnabled": true,
		    "description": "Admins can manage roles and perform all event actions.",
		    "value": "EventAdmin"
	    },{
		    "allowedMemberTypes": [
			    "User"
		    ],
		    "displayName": "Global Admin",
		    "id": "212C70F6-EF65-4004-B223-A72694F77812",
		    "isEnabled": true,
		    "description": "Full control",
		    "value": "GlobalAdmin"
	    }
    ],

3) Add role based authorization to each endpoint