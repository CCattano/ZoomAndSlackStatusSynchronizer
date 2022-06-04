# Zoom And Slack Status Synchronizer

Web API that listens for Zoom status change that indicates you've joined a meeting.

When it is detected you have joined a meeting the API sets your Slack status to, "In Zoom Meeting"

-----

# High Level Setup Explanation

This isn't the easiest setup, but it works, so 🤷‍♂️

To make this work I

1. Opened a port on my network w/ port forwarding
3. Added a inbound traffic rule to the firewall of my target machine on my network
4. Created a Zoom Webhook App on Zoom's website
5. Registered a listener for the User Status Change event in the app
6. Specified the event should go to public IP at the port I opened

This covers the Zoom part

Slack was easier as I didn't need to do any networking shenanigans

1. I registered an app with my Slack workspace requiring the users.profile:write permission
2. After installing the app I got an OAuth token I could use in the web req this program makes

All in all this enables me to receive status changes fropm Zoom, then act on them in Slack
