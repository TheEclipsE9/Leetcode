using static Leetcode.Test.Leetcode.Design.MediumMyCalendarTwoTest.MyCalendarTwo;

namespace Leetcode.Test.Leetcode.Design
{
    public class MediumMyCalendarTwoTest
    {
        [Fact]
        public void Test()
        {
            MyCalendarTwo myCalendarTwo = new MyCalendarTwo();

            bool res = false;

            res = myCalendarTwo.Book(26, 35);
            res = myCalendarTwo.Book(26, 32);
            res = myCalendarTwo.Book(25, 32);
            res = myCalendarTwo.Book(18, 26);
            res = myCalendarTwo.Book(40, 45);
            res = myCalendarTwo.Book(19, 26);
            res = myCalendarTwo.Book(48, 50);

            //res = myCalendarTwo.Book(10, 20);
            //res = myCalendarTwo.Book(50, 60);
            //res = myCalendarTwo.Book(10, 40);
            //res = myCalendarTwo.Book(5, 15);
            //res = myCalendarTwo.Book(5, 10);
            //res = myCalendarTwo.Book(25, 55);
        }


        public class MyCalendarTwo
        {
            public List<CalendarEvent> _calendarEvents = new();

            public List<CalendarEvent> _doublyBookedRanges = new();

            public MyCalendarTwo()
            {

            }

            public bool Book(int start, int end)
            {
                foreach (var item in _doublyBookedRanges)
                {
                    if (IsIntersected(start, end, item))
                    {
                        return false;
                    }
                }
                foreach (var item in _calendarEvents)
                {
                    if (IsIntersected(start, end, item))
                    {
                        var res = Cut(start, end, item);

                        _doublyBookedRanges.Add(res);
                    }
                }

                _calendarEvents.Add(new CalendarEvent(start, end));


                return true;

                bool IsIntersected(int start, int end, CalendarEvent calendarEvent)
                {
                    if (start < calendarEvent.End && end > calendarEvent.Start)
                    {
                        return true;
                    }
                    return false;
                }

                CalendarEvent Cut(int start, int end, CalendarEvent calendarEvent)
                {
                    List<CalendarEvent> events = new();

                    int newDoublyBookedStart;
                    int newDoublyBookedEnd;

                    //no if use max start and min end
                    if (start <= calendarEvent.Start)
                    {
                        newDoublyBookedStart = calendarEvent.Start;
                    }
                    else
                    {
                        newDoublyBookedStart = start;
                    }

                    if (end <= calendarEvent.End)
                    {
                        newDoublyBookedEnd = end;
                    }
                    else
                    {
                        newDoublyBookedEnd = calendarEvent.End;
                    }


                    return new CalendarEvent(newDoublyBookedStart, newDoublyBookedEnd);
                }
            }

            private readonly Dictionary<int, int> bookedNumbers = new();
            public bool Book_outofMemory(int start, int end)
            {
                if (IsTripleBooking(start, end)) return false;
                _calendarEvents.Add(new CalendarEvent(start, end));

                return true;

                bool IsTripleBooking(int newEventStart, int newEventEnd)
                {
                    for (int i = newEventStart; i < newEventEnd; i++)
                    {
                        if (bookedNumbers.TryGetValue(i, out int value))
                        {
                            if (value == 1)
                            {
                                for (int j = newEventStart; j < i; j++)
                                {
                                    bookedNumbers[j] = bookedNumbers[j] - 1;
                                }
                                return true;
                            }
                            bookedNumbers[i] = value + 1;
                        }
                        else
                        {
                            bookedNumbers.Add(i, 0);
                        }
                    }

                    return false;
                }
            }

            public bool Book_TimeException(int start, int end)
            {
                Dictionary<int, int> newEventNumbers = new();
                for (int i = start; i < end; i++)
                {
                    newEventNumbers.Add(i, 0);
                }
                foreach (var item in _calendarEvents)
                {
                    var res = IsTripleBooking(item.Start, item.End);
                    if (res == true)
                    {
                        return false;
                    }
                }

                _calendarEvents.Add(new CalendarEvent(start, end));

                return true;

                bool IsTripleBooking(int existingEventStart, int existingEventEnd)
                {
                    for (int i = existingEventStart; i < existingEventEnd; i++)
                    {
                        if (newEventNumbers.TryGetValue(i, out int value))
                        {
                            if (value == 1)
                            {
                                return true;
                            }
                            newEventNumbers[i] = value + 1;
                        }
                    }

                    return false;
                }
            }

            public bool Book_old(int start, int end)
            {
                List<CalendarEvent> calendarEvents = new(2);

                int intersectionsCount = 0;
                foreach (var item in _calendarEvents)
                {
                    var isIntersects = IsIntersects_old(start, end, item);
                    if (isIntersects)
                    {
                        intersectionsCount++;
                        calendarEvents.Add(item);
                    }
                    if (intersectionsCount == 3)
                    {
                        return false;
                    }
                }
                if (intersectionsCount == 2)
                {
                    var res = IsIntersects_old(calendarEvents[0].Start, calendarEvents[0].End, calendarEvents[1]);
                    if (res == true)
                    {
                        return false;
                    }
                }
                _calendarEvents.Add(new CalendarEvent(start, end));

                return true;
            }

            private bool IsIntersects_old(int start, int end, CalendarEvent calendarEvent)
            {
                HashSet<int> bookedNumbers = new HashSet<int>();
                for (int i = start; i < end; i++)
                {
                    bookedNumbers.Add(i);
                }

                for (int i = calendarEvent.Start; i < calendarEvent.End; i++)
                {
                    if (bookedNumbers.Contains(i))
                    {
                        return true;
                    }
                }

                return false;
            }

            public struct CalendarEvent
            {
                public int Start;
                public int End;

                public CalendarEvent(int start, int end)
                {
                    Start = start;
                    End = end;
                }
            }
        }
    }
}
