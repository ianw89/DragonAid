function update(item, user, request) {
    getOriginalAsync("character", item.Id, {
        error: request.respond,
        success: function(original) {
            updateImpl(item, original, user, request);
        }
    });
}

function updateImpl(item, original, user, request) {
    if (original.userId != user.userId) {
        console.log("User %s attempted to illegally modify Character %s", user.userId, item.Id);
        // FORBIDDEN is more accurate, but we don't want to expose a means of identifying which resources exist on our server
        request.respond(statusCodes.NOT_FOUND);
        return;
    }
    
    if (original.lastUpdated != item.lastUpdated) {
        request.respond(statusCodes.CONFLICT, "Character is stale. Refresh and retry the update.");
        return;
    }
    
    item.lastUpdated = new Date();
    request.execute();
}

// Attempts to retrieve the version of the item that existed before this update request
// This method is asynchronous. options MUST contain the following continuation members:
//     success, a void function taking a character
//     error, a void function taking an HTTP status code
function getOriginalAsync(tableName, id, options) {
    tables.getTable(tableName).where({
        Id: id
    }).read({
        success: function(results) {
            if (results.length === 0) {
                options.error(statusCodes.NOT_FOUND);
            } else if (results.length > 1) {
                console.error("Duplicate item ID %s", item.Id);
                options.error(statusCodes.INTERNAL_SERVER_ERROR);
            } else {
                options.success(results[0]);
            }
        }
    });
}