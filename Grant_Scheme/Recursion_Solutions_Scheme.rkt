#lang scheme/base

; some definitions to make more sense to non-lispers
(define (head l) (car l))
(define (tail l) (cdr l))

;*****************
;***** Basic *****
;*****************

(define (factorial n)
  (cond 
    ((eq? n 0) 1)
    (else (* n (factorial (- n 1))))))

'(Factorial 5)
(factorial 5)

(define (gcd p q)
  (cond 
    ((= q 0) p)
    (else (gcd q (modulo p q)))))

'(gcd 102 68)
(gcd 102 68)

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

(define (isEven? n)
  (cond 
    ((eq? n 0) #t)
    (else (isOdd? (- n 1)))))

(define (isOdd? n)
  (cond 
    ((eq? n 0) #f)
    (else (isEven? (- n 1)))))

'(odd/even)
(even? 99)
;(even? 888)
;(odd? 99)
;(odd? 888)

;************************
;***** Intermediate *****
;************************

(define (ackermann m n)
  (cond 
    ((= m 0) (+ n 1))
    ((= n 0) (ackermann (- m 1) 1))
    (else (ackermann (- m 1) (ackermann m (- n 1))))))

'(ackermann )
;(ackermann 3 12)

(define (atom? x)
  (and (not (pair? x)) (not (null? x))))

(define (treesearch item list)
  (cond 
    ((null? list) #f)
    ((atom? (head list)) (or (eq? (head list) item)
                             (treesearch item (cdr list))))
    (else (or (treesearch item (car list))
              (treesearch item (cdr list))))))

'(treesearch)
(treesearch 9 '(1 2 (3) (4 5 (6 (7)) 8 ((9)))))
;(treesearch 9 '(((9)) 2 (3) (4 5 (6 (7)) 8)))
;(treesearch 9 '(1 2 (3) (4 5 (6 (7)) 8 (()))))

(define (range-to n)
  (cond
    ((= n 0) '())
    (else (cons n (range-to (- n 1))))))

; scheme seems to have no trouble with stack overflows even
; when not doing tail calls, probably due to its dynamic nature
(define (count-tail item list acc)
  (cond 
    ((null? list) acc)
    (else (count-tail item 
                      (tail list)
                      (+ acc
                         (if (= (head list) item) 1 0))))))

'(count-tail 99 (0-100000))
(count-tail 99 (range-to 100000) 0)

(define (evens-tail list acc)
  (cond 
    ((null? list) acc)
    ((even? (head list)) (evens-tail (tail list) (cons (head list) acc)))
    (else (evens-tail (tail list) acc))))

'(evens-tail 1 2 3 4 5 6 7 8)
(evens-tail '(1 2 3 4 5 6 7 8) '())