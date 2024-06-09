import React from 'react';
import { observer } from 'mobx-react-lite';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { useForm } from 'react-hook-form';
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
} from '@/components/ui/form';
import { IEditDocumentModalVM } from '@/components/documents/DocumentEditingModal/EditDocumentModal.vm';
import { IDocument } from '@/data/abstractions/IDocument';

interface IEditDocumentModal {
  document: IDocument;
}

const EditDocumentModal: React.FC<IEditDocumentModal> = ({document}) => {
  const vm = useGet<IEditDocumentModalVM>(
    ServiceSymbols.IDocumentEditingModalVM,
  );

  vm.document = document;

  const form = useForm<z.infer<typeof vm.editFormSchema>>({
    resolver: zodResolver(vm.editFormSchema),
  });

  return (
    <Dialog open={vm.isOpened} onOpenChange={vm.setIsOpened}>
      <DialogTrigger asChild>
        <Button variant='invisible' size='invisible'>
          Редактировать
        </Button>
      </DialogTrigger>
      <DialogContent className='sm:max-w-[425px] max-w-[90%] gap-6'>
        <DialogHeader>
          <DialogTitle>Редактирование документа</DialogTitle>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(vm.editDocument)}>
            <div className='grid w-full items-center gap-6'>
              <FormField
                control={form.control}
                name='documentName'
                render={({ field }) => (
                  <FormItem className='flex flex-col space-y-3'>
                    <Label htmlFor='documentName'>Название документа</Label>
                    <FormControl>
                      <Input
                        id='documentName'
                        placeholder='Название документа'
                        autoComplete='off'
                        autoCorrect='off'
                        defaultValue={document.name}
                        disabled={vm.isLoading}
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <DialogFooter>
                <Button type='submit' className='m-1'>
                  Сохранить
                </Button>
                <DialogClose asChild className='m-1'>
                  <Button type='button' variant='secondary'>
                    Отмена
                  </Button>
                </DialogClose>
              </DialogFooter>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default observer(EditDocumentModal);
