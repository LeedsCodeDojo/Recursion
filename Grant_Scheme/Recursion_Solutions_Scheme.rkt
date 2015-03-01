#lang scheme/base

; some definitions to make more sense to non-lispers
(define (head l) (car l))
(define (tail l) (cdr l))

(define (factorial n)
  (cond 
    ((eq? n 0) 1)
    (else (* n (factorial (- n 1))))))

'(Factorial 5)
(factorial 5)

(define (fibonacci n)
  (cond 
    ((< n 2) 1)
    (else (+ (fibonacci (- n 1)) (fibonacci (- n 2))))))

'(fibonacci 7)
(fibonacci 7)

(define (sum list)
  (cond 
    ((null? list) 0)
    (else (+ (head list) 
             (sum (tail list))))))

'(Sum 1 2 3 4 5)
(sum '(1 2 3 4 5))

(define (count item list)
  (cond 
    ((null? list) 0)
    (else (+ (cond ((= (head list) item) 1) (else 0))
             (count item (tail list))))))

'(count 1 '(1 2 1 3 4 1))
(count 1 '(1 2 1 3 4 1))

(define (even? n)
  (= (modulo n 2) 0))

(define (evens list)
  (cond 
    ((null? list) '())
    ((even? (head list)) (cons (head list)
                               (evens (tail list))))
    (else (evens (tail list)))))

'(evens 1 2 3 4 5 6 7 8)
(evens '(1 2 3 4 5 6 7 8))