import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import { IMessage } from '@/data/abstractions/IMessage';
import moment from 'moment';
import type { RefObject } from 'react';
import { createRef } from 'react';
import { MessagesExample } from '@/components/chat-bot/chat-bot.test-data';

export interface IChatBotVM {
  messages: IMessage[];
  sendRequest: (request: string) => void;
  messagesEndRef: RefObject<HTMLDivElement>;
  scrollToBottom: () => void;
  isLoading: boolean;
}

@injectable()
class ChatBotVM implements IChatBotVM {
  @observable
  public messages: IMessage[] = [];

  @observable
  public isLoading: boolean = false;

  @observable
  public readonly messagesEndRef: RefObject<HTMLDivElement> =
    createRef<HTMLDivElement>();

  constructor() {
    this.scrollToBottom();
    makeObservable(this);
  }

  @action
  public scrollToBottom = () => {
    setTimeout(() => {
      if (this.messagesEndRef.current)
        this.messagesEndRef.current.scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });
    }, 100);
  };

  @action
  public sendRequest = (request: string) => {
    if (request === 'example') {
      this.messages = MessagesExample;
    } else {
      this.messages.push({
        id: this.messages.length + 1,
        type: 'user',
        text: request,
        timestamp: moment().format('YYYY-MM-DD HH:mm:ss'),
      });
    }

    this.isLoading = true;

    this.scrollToBottom();

    setTimeout(() => {
      this.messages.push({
        id: this.messages.length + 1,
        type: 'bot',
        text: request.repeat(10),
        timestamp: moment().format('YYYY-MM-DD HH:mm:ss'),
      });
      this.isLoading = false
    }, 3000);
  };
}

export default ChatBotVM;
