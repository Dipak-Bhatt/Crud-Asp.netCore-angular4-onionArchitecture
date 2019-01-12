import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Messages } from './ServiceResponse';

export class MessageService {
  private messageSource = new BehaviorSubject<any>('');
  currentMessage = this.messageSource.asObservable();
  message:Messages[]
  constructor() { }

  changeMessage(message: Messages[]) {
    this.messageSource.next(message);
  }

}
