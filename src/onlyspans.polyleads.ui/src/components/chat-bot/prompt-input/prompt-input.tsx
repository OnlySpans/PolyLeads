'use client';

import { observer } from 'mobx-react-lite';
import React, { FC } from 'react';
import useGet from '@/hooks/useGet';
import { IPromptInputVM } from '@/components/chat-bot/prompt-input/prompt-input.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { Textarea } from '@/components/ui/textarea';
import { Button } from '@/components/ui/button';
import { SendHorizontal } from 'lucide-react';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';

const PromptInput: FC = () => {
  const vm = useGet<IPromptInputVM>(ServiceSymbols.IPromptInputVM);
  const chatBotVM = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  return (
    <div className='flex gap-4 items-end'>
      <Textarea
        id='requestForm'
        ref={vm.textareaRef}
        value={vm.value}
        disabled={chatBotVM.isLoading}
        onChange={(e) => vm.setValue(e.target.value)}
        placeholder='Введите запрос'
        className='resize-none max-h-40 text-base 2xl:text-lg'
      />
      <Button
        className='w-10 h-10 p-3'
        onClick={vm.sendPrompt}
        disabled={chatBotVM.isLoading}
      >
        <SendHorizontal />
      </Button>
    </div>
  );
};

export default observer(PromptInput);
