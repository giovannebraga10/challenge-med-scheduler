"use client";
import { useCallback, useMemo, useState } from "react";

export function useStepper(total: number, initial = 0) {
  const [index, setIndex] = useState(initial);

  const isFirst = index === 0;
  const isLast = index === total - 1;

  const next = useCallback(() => setIndex((i) => Math.min(i + 1, total - 1)), [total]);
  const back = useCallback(() => setIndex((i) => Math.max(i - 1, 0)), []);
  const goTo = useCallback((i: number) => {
    setIndex(Math.max(0, Math.min(i, total - 1)));
  }, [total]);

  const progress = useMemo(() => (total ? ((index + 1) / total) * 100 : 0), [index, total]);

  return { index, isFirst, isLast, next, back, goTo, progress, total };
}
