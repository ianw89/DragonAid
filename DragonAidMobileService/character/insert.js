function insert(item, user, request) {
    item.userId = user.userId;
    item.lastUpdated = new Date();
    request.execute();
}