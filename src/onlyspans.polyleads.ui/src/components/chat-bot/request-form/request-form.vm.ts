import { inject, injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';
import type { RefObject } from 'react';
import { createRef } from 'react';

export interface IRequestFormVM {
  value: string;
  setValue: (value: string) => void;
  sendRequest: () => void;
  sendExampleRequest: (request: string) => void;
  textareaRef: RefObject<HTMLTextAreaElement>;
}

@injectable()
class RequestFormVM implements IRequestFormVM {
  @observable
  public value: string = '';

  private readonly chatBotVM: IChatBotVM;

  @observable
  public readonly textareaRef: RefObject<HTMLTextAreaElement> =
    createRef<HTMLTextAreaElement>();

  constructor(@inject(ServiceSymbols.IChatBotVM) chatBotVM: IChatBotVM) {
    this.chatBotVM = chatBotVM;
    makeObservable(this);
  }

  @action
  public setValue = (value: string) => {
    this.value = value;

    const textarea = this.textareaRef.current;
    if (textarea) {
      textarea.style.height = 'auto';
      textarea.style.height = `${textarea.scrollHeight}px`;
    }
  };

  @action
  public sendRequest = () => {
    this.chatBotVM.sendRequest(this.value)
    this.value = '';
  };

  @action
  public sendExampleRequest = (request: string) => {
    this.value = request;
    this.sendRequest();
  };
}

export default RequestFormVM;
