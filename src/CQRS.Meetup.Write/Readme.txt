dotnet ef migrations add XXXXX --project CQRS.Meetup.Infra --startup-project CQRS.Meetup.Web
dotnet ef database update --project CQRS.Meetup.Infra --startup-project CQRS.Meetup.Web