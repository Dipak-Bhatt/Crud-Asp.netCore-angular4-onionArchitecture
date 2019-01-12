"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var MessageService = /** @class */ (function () {
    function MessageService() {
        this.messageSource = new rxjs_1.BehaviorSubject('');
        this.currentMessage = this.messageSource.asObservable();
    }
    MessageService.prototype.changeMessage = function (message) {
        this.messageSource.next(message);
    };
    return MessageService;
}());
exports.MessageService = MessageService;
//# sourceMappingURL=messageService.js.map