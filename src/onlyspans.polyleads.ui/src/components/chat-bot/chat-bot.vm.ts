import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import { IMessage } from '@/data/abstractions/IMessage';
import moment from 'moment';
import { MessagesExample } from '@/components/chat-bot/chat-bot.test-data';

export interface IChatBotVM {
  messages: IMessage[];
  sendRequest: (request: string) => void;
}

@injectable()
class ChatBotVM implements IChatBotVM {
  @observable
  public messages: IMessage[] = [];

  constructor() {
    this.messages = MessagesExample
    makeObservable(this);
  }

  @action
  public sendRequest = (request: string) => {
    this.messages.push({
      id: 1,
      type: 'user',
      text: request,
      timestamp: moment().format('YYYY-MM-DD HH:mm:ss')
    })
    console.log(this.messages)
  };
}

export default ChatBotVM;
