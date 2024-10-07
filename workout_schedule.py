from icalendar import Calendar, Event
from datetime import datetime, timedelta

# Create a calendar
cal = Calendar()

# Define the workout events based on the user's schedule
workout_events = [
    {"summary": "Running: 5-7 miles", "start": datetime(2024, 10, 8, 7, 0), "duration": 60},
    {"summary": "Biking: 60 min, moderate pace", "start": datetime(2024, 10, 9, 7, 0), "duration": 60},
    {"summary": "Strength Training: Leg Day", "start": datetime(2024, 10, 10, 7, 0), "duration": 60},
    {"summary": "Running: 3-4 miles (intervals or hill sprints)", "start": datetime(2024, 10, 11, 7, 0), "duration": 45},
    {"summary": "Biking: 75-90 min endurance ride", "start": datetime(2024, 10, 12, 7, 0), "duration": 90},
    {"summary": "Rest or Light Recovery", "start": datetime(2024, 10, 13, 7, 0), "duration": 30},
]

# Add events to the calendar
for event_data in workout_events:
    event = Event()
    event.add("summary", event_data["summary"])
    event.add("dtstart", event_data["start"])
    event.add("dtend", event_data["start"] + timedelta(minutes=event_data["duration"]))
    event.add("dtstamp", datetime.now())
    cal.add_component(event)

# Save the calendar to a .ics file
with open("workout_schedule.ics", "wb") as f:
    f.write(cal.to_ical())

print("Workout schedule saved as 'workout_schedule.ics'")
