<script>
	let { trigger, id, onDelete, onEdit } = $props();
	let isEditing = $state(false);
	let isDisabled = $state(true);

	function toggleEditMode() {
		isEditing = !isEditing;
		if (isEditing) {
			isDisabled = false;
		} else {
			isDisabled = true;
		}
	}

	function handleEdit(id) {
		onEdit(id, trigger);
		toggleEditMode();
	}
</script>

<article>
	<input type="text" bind:value={trigger} name="" disabled={isDisabled} />
	<div class="btn-container">
		{#if !isEditing}
			<button onclick={() => toggleEditMode()}>Edit</button>
			<button onclick={() => onDelete(id)}>Delete</button>
		{:else}
			<button onclick={() => handleEdit(id)}>Save</button>
			<button onclick={() => toggleEditMode()}>Cancel</button>
		{/if}
	</div>
</article>

<style>
	article {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
	}

	input {
		display: flex;
		flex-direction: column;
	}

	.btn-container {
		display: flex;
		flex-direction: column;
		gap: 1rem;
	}
</style>
