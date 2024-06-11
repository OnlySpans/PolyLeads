'use client';

import { observer } from 'mobx-react-lite';
import React, { FC, useEffect, useRef } from 'react';
import useGet from '@/hooks/useGet';
import { IRequestFormVM } from '@/components/chat-bot/request-form/request-form.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { Textarea } from '@/components/ui/textarea';
import { Button } from '@/components/ui/button';
import { SendHorizontal } from 'lucide-react';

const RequestForm: FC = () => {
  const vm = useGet<IRequestFormVM>(ServiceSymbols.IRequestFormVM);
  const textareaRef = useRef<HTMLTextAreaElement>(null);

  useEffect(() => {
    const textarea = textareaRef.current;
    if (textarea) {
      textarea.style.height = 'auto';
      textarea.style.height = `${textarea.scrollHeight}px`;
    }
  }, [vm.value]);

  return (
    <div className='flex gap-4 items-end'>
      <Textarea
        id='requestForm'
        ref={textareaRef}
        onChange={(e) => vm.setValue(e.target.value)}
        placeholder='Введите запрос'
        className={`resize-none max-h-32`}
      />
      <Button className='w-10 h-10 p-3' onClick={() => {}}>
        <SendHorizontal />
      </Button>
    </div>
  );
};

export default observer(RequestForm);
