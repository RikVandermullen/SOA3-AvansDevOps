using AvansDevOps.Domain;

BacklogItem item = new BacklogItem();

Activity activity1 = new Activity();
Activity activity2 = new Activity();

item.AddActivity(activity1);
item.AddActivity(activity2);

item.SetToDoing();
item.SetToReadyForTesting();
item.SetToTesting();
item.SetToTested();
item.SetToDone();