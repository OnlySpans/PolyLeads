import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import { IMessage } from '@/data/abstractions/IMessage';
import moment from 'moment';
import { MessagesExample } from '@/components/chat-bot/chat-bot.test-data';
import type { RefObject } from 'react';
import { createRef } from 'react';

export interface IChatBotVM {
  messages: IMessage[];
  sendRequest: (request: string) => void;
  messagesEndRef: RefObject<HTMLDivElement>;
  scrollToBottom: () => void;
}

@injectable()
class ChatBotVM implements IChatBotVM {
  @observable
  public messages: IMessage[] = [];

  @observable
  public readonly messagesEndRef: RefObject<HTMLDivElement> =
    createRef<HTMLDivElement>();

  constructor() {
    this.messages = MessagesExample;

    makeObservable(this);
  }

  @action
  public scrollToBottom = () => {
    if (this.messagesEndRef.current) {
      this.messagesEndRef.current.scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });
    }
  };

  @action
  public sendRequest = (request: string) => {
    this.messages.push({
      id: this.messages.length + 1,
      type: 'user',
      text: request,
      timestamp: moment().format('YYYY-MM-DD HH:mm:ss'),
    });

    setTimeout(() => {
      this.scrollToBottom();
    }, 100);
  };
}

export default ChatBotVM;
