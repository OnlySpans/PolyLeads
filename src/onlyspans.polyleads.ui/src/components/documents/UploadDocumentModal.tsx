import React from 'react';
import { observer } from 'mobx-react-lite';
import {
  Dialog, DialogClose,
  DialogContent, DialogDescription, DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import useGet from '@/hooks/useGet';
import { IUploadDocumentModalVM } from '@/components/documents/UploadDocumentModal.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { useForm } from 'react-hook-form';
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { Form, FormControl, FormField, FormItem, FormMessage } from '@/components/ui/form';

const UploadDocumentModal: React.FC = () => {
  const vm = useGet<IUploadDocumentModalVM>(
    ServiceSymbols.IUploadDocumentModalVM);

  const form = useForm<z.infer<typeof vm.uploadFormSchema>>({
    resolver: zodResolver(vm.uploadFormSchema),
  });

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="default">Добавить файл</Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[425px]">
        <DialogHeader>
          <DialogTitle>Добавить файл</DialogTitle>
          <DialogDescription>
            Файл будет распознан спустя некоторое время
          </DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form>
            <div className="grid w-full items-center gap-4">
              <FormField
                control={form.control}
                name='documentName'
                render={({ field }) => (
                  <FormItem className="flex flex-col space-y-3">
                    <Label htmlFor="documentName">Название документа</Label>
                    <FormControl>
                      <Input
                        id='documentName'
                        placeholder='Название документа'
                        autoComplete='off'
                        autoCorrect='off'
                        // disabled={vm.isLoading}
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name='url'
                render={({ field }) => (
                  <FormItem className="flex flex-col space-y-3">
                    <Label htmlFor="source-link">Ссылка на файл</Label>
                    <FormControl>
                      <Input
                        id='url'
                        placeholder='Ссылка'
                        autoComplete='off'
                        autoCorrect='off'
                        // disabled={vm.isLoading}
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </div>
          </form>
        </Form>
        <DialogFooter>
          <DialogClose asChild className="m-1">
            <Button type="button" variant="secondary">
              Отмена
            </Button>
          </DialogClose>
          <Button type="submit" className="m-1">Загрузить</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  )
}

export default observer(UploadDocumentModal);
