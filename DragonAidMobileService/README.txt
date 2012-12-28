This folder contains the server-side scripts registered to the DragonAid-msvc Azure Mobile Service

It doesn't build anything to be used client side, and the scripts registered to the real service need to be manually registered after being changed here. They exist here purely for the sake of keeping them under version control.

Folders map to database tables. Each folder should contain some subset of insert.js, update.js, read.js, and delete.js. Most models need to override all of these, at least for the sake of handling user authorization. If a file is missing, assume it should use the default provided by Azure.