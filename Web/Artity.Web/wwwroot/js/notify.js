var connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/notify")
        .build();

connection.start();
