'use client';

import { Button } from '@/components/ui/button';
import { Textarea } from '@/components/ui/textarea';
import { SendHorizontal } from 'lucide-react';

const RequestForm = () => {
  return (
    <div className='flex px-8 py-4 gap-4 items-end'>
      <Textarea
        id='requestForm'
        placeholder='Введите запрос'
        className='resize-none '
      />
      <Button className='w-10 h-10 p-3'>
        <SendHorizontal />
      </Button>
    </div>
  );
};

export default RequestForm;
