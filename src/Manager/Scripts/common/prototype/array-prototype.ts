﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

interface Array<T> {
	take(count: number): Array<T>;
	skip(count: number): Array<T>;
	chunk(size: number): Array<Array<T>>;
}

/**
 * Takes the first `n` elements from the array.
 * @param {number} count - Number of elements to take.
 * @returns {Array<T>} A new array containing the first `n` elements.
 */
Array.prototype.take = function <T>(count: number): Array<T> {
	if (count < 0) {
		throw new Error("Number of elements to take must be non-negative");
	}

	return this.slice(0, count);
};
/**
 * Skips the first `n` elements of the array.
 * @param {number} count - Number of elements to skip.
 * @returns {Array<T>} A new array containing all elements after the first `n` elements.
 */
Array.prototype.skip = function <T>(count: number): Array<T> {
	if (count < 0) {
		throw new Error("Number of elements to skip must be non-negative");
	}
	return this.slice(count);
};
/**
 * Splits the array into chunks of the specified size.
 * @param {number} size - Size of each chunk.
 * @returns {Array<Array<T>>} A new array containing arrays of the specified size.
 */
Array.prototype.chunk = function <T>(size: number): Array<Array<T>> {
	if (size <= 0) {
		throw new Error("Chunk size must be greater than zero");
	}

	const result: Array<Array<T>> = [];
	for (let index = 0; index < this.length; index += size) {
		result.push(this.slice(index, index + size));
	}
	return result;
};
