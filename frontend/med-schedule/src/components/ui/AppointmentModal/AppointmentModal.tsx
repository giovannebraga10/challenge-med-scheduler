"use client";

import { Dialog, DialogPanel, DialogTitle, Description } from "@headlessui/react";
import { useForm, FormProvider } from "react-hook-form";
import { useStepper } from "@/hooks/useStepper";
import { useState } from "react";

type FormData = {
  name: string;
  email: string;
  date: string;
  time: string;
  notes?: string;
  doctor: string;

};

type Doctor = {
  id: number;
  name: string;
  time: string;
}

interface AppointmentModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSubmitSuccess?: (data: FormData) => void;
}

const stepsLabels = ["Seus dados", "Agendamento", "Confirmar"];

export default function AppointmentModal({ isOpen, onClose, onSubmitSuccess }: AppointmentModalProps) {
  const [optionsList, setOptionsList] = useState<string[]>([]);
  const [selectedOption, setSelectedOption] = useState<string | null>(null);

  const doctors: Doctor[] = [
    { id: 1, name: "Dr. João Silva", time: "09:00 - 10:00" },
    { id: 2, name: "Dra. Maria Oliveira", time: "10:00 - 11:00" },
    { id: 3, name: "Dr. Pedro Santos", time: "11:00 - 12:00" },
  ];

  const methods = useForm<FormData>({
    defaultValues: { name: "", email: "", date: "", time: "", notes: "" },
    mode: "onTouched",
  });
  const { register, handleSubmit, trigger, formState } = methods;

  const stepFields: (keyof FormData)[][] = [
    ["name", "email"],
    ["date", "time"],
    [],
  ];


  const { index, isFirst, isLast, next, back, progress } = useStepper(stepsLabels.length);

  const submitAll = handleSubmit((data) => {
    onSubmitSuccess?.(data);
    onClose();
  });


  const handleNext = async () => {
    const fields = stepFields[index] as (keyof FormData)[];
    const valid = fields.length ? await trigger(fields) : true;
    if (!valid) return;

    if (index === 1) {
      next();
      return;
    }

    if (index === 1) {
      try {
        const values = methods.getValues();
        const res = await fetch("/api/sintomas", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(values),
        });

        if (res.ok) {
          alert("Erro ao enviar os sintomas. Tente novamente.");
          return;
        }

        const data = await res.json();
        setOptionsList(data.options || ["Dr. João", "Dr. Maria", "Dr. Ana"]);
      } catch (err) {
        console.error(err);
        alert("Erro de conexão com o servidor.");
        return;
      }
    }

    next();
  };

  return (
    <Dialog open={isOpen} onClose={onClose} className="relative z-50">

      <div className="fixed inset-0 bg-black/50" aria-hidden="true" />

      <div className="fixed inset-0 flex items-center justify-center p-4">
        <DialogPanel className="w-full max-w-xl rounded-2xl bg-white p-6 shadow-xl">
          <DialogTitle className="text-xl font-semibold">{stepsLabels[index]}</DialogTitle>
          <Description className="mt-1 text-sm text-gray-600">
            Preencha os dados e avance. Você pode voltar a qualquer momento.
          </Description>

          {/* Barra de progresso */}
          <div className="mt-4 h-1 w-full rounded bg-gray-200">
            <div
              className="h-1 rounded bg-blue-600 transition-all"
              style={{ width: `${progress}%` }}
            />
          </div>

          <FormProvider {...methods}>
            <form className="mt-6 space-y-6" onSubmit={submitAll}>
              {/* PASSO 1 */}
              {index === 0 && (
                <div className="grid gap-4 sm:grid-cols-2 items-center content-center justify-center">
                  <div>
                    <label className="block text-sm font-medium">Data do agendamento</label>
                    <input
                      type="date"
                      {...register("date", { required: "Escolha uma data" })}
                      className="mt-1 w-full rounded border p-2 outline-none focus:ring-2 focus:ring-blue-500"
                    />
                    {formState.errors.date && (
                      <p className="mt-1 text-xs text-red-600">{formState.errors.date.message}</p>
                    )}
                  </div>
                </div>
              )}

              {/* PASSO 2 */}
              {index === 1 && (
                <div className="grid gap-4 sm:grid-cols-2">

                  <div className="sm:col-span-2">
                    <label className="block text-sm font-medium">Sintomas</label>
                    <textarea
                      rows={3}
                      {...register("notes")}
                      className="mt-1 w-full rounded border p-2 outline-none focus:ring-2 focus:ring-blue-500"
                      placeholder="Algo que precisamos saber?"
                    />
                  </div>
                </div>
              )}

              {/* PASSO 3 */}
              {index === 2 && (
                <div>
                  <label className="block mb-2 font-semibold">Escolha o médico</label>
                  <div className=" rounded-md divide-y">
                    {doctors.map((doctor) => {
                      const selectedDoctor = methods.watch("doctor") === doctor.name;
                      return (
                        <div
                          key={doctor.id}
                          onClick={() => methods.setValue("doctor", doctor.name, { shouldValidate: true })}
                          className={`flex justify-between items-center p-3 cursor-pointer transition-colors
              ${selectedDoctor ? "bg-blue-100" : "hover:bg-gray-100"}`}
                        >
                          <span className="font-medium">{doctor.name}</span>
                          <span className="text-sm text-gray-600">{doctor.time}</span>
                        </div>
                      );
                    })}
                  </div>
                  {/* mensagem de erro */}
                  {methods.formState.errors.doctor && (
                    <p className="text-red-500 text-sm mt-1">
                      {methods.formState.errors.doctor.message as string}
                    </p>
                  )}
                </div>
              )}



              {/* PASSO 4 */}
              {index === 3 && (
                <div className="space-y-2 text-sm">
                  <p>Revise os dados antes de confirmar:</p>
                  {/* Em um caso real, você pode puxar os valores com getValues() e renderizar aqui */}
                </div>
              )}

              {/* FOOTER */}
              <div className="mt-2 flex items-center justify-between">
                <div className="flex gap-2">
                  {stepsLabels.map((label, i) => (
                    <div
                      key={label}
                      className={`h-2 w-2 rounded-full ${i <= index ? "bg-blue-600" : "bg-gray-300"}`}
                      aria-label={label}
                    />
                  ))}
                </div>

                <div className="flex gap-2">
                  <button
                    type="button"
                    onClick={isFirst ? onClose : back}
                    className="rounded border px-4 py-2 text-sm"
                  >
                    {isFirst ? "Cancelar" : "Voltar"}
                  </button>

                  {!isLast && (
                    <button
                      type="button"
                      onClick={handleNext}
                      className="rounded bg-blue-600 px-4 py-2 text-sm text-white"
                    >
                      Próximo
                    </button>
                  )}

                  {isLast && (
                    <button
                      type="submit"
                      className="rounded bg-green-600 px-4 py-2 text-sm text-white"
                    >
                      Confirmar
                    </button>
                  )}
                </div>
              </div>
            </form>
          </FormProvider>
        </DialogPanel>
      </div>
    </Dialog>
  );
}
